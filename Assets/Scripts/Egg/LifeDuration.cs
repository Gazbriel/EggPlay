using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeDuration : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadEgg();
        egglifescopy = eggLife;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHigherPosition();//Controls the las higer position
        DamageController();//defines if the egg can be hurt
        VerifyEggLife();//clear as water
	}

    #region Load Egg
    //this funtion in the future is gonna load the Egg that the players is currently using
    //but now just load a value:
    public void LoadEgg()
    {
        //eggLife = 3;

        

        //pass the value to the braker layer controller
        GetComponentInChildren<BrakeLayerController>().SetStarterLife(egglifescopy);

        //pass the value to the UI and start the ui funcion
        GameObject.Find("Lifes").GetComponent<EggLifeUI>().SetEggLifesCounter(eggLife);
        GameObject.Find("Lifes").GetComponent<EggLifeUI>().CreateStartingLifes();
    }
    //this is for reset the egg lifes
    private int egglifescopy;
    //----------------------------------

    public int GetStarterLife()
    {
        return 3;
    }
    #endregion

    #region Damage Region
    private bool eggIsDead;
    public int eggLife;
    public int GetEggLife()
    {
        return eggLife;
    }
    public float damageHight;
    public float maxDamageHight;
    public float sideVelocityDamage;
    private float higherPosition;
    private void UpdateHigherPosition()
    {
        if (transform.position.y > higherPosition)
        {
            higherPosition = transform.position.y;
        }
    }
    public void Damage()//this one verifies if damage can be done due to vertical fall.
    {
        if (canDamage && (higherPosition - transform.position.y) > damageHight)
        {
            if (canDamage && (higherPosition - transform.position.y) > maxDamageHight)
            {
                //Eliminate the ui eggs
                GameObject.Find("Lifes").GetComponent<EggLifeUI>().SetAllFalse();
                //---------------------------------------------------------------
                eggLife = 0;
            }
            DoDamage();
        }
        //else if (canDamage)// this is for the sound efect when toucjes the ground
        //{
        //    FindObjectOfType<AudioManager>().Play("Ground Touch");
        //}
        canDamage = false;
    }
    public void DoDamage()//this do the damage no matter what
    {
        GameObject.Find("Lifes").GetComponent<EggLifeUI>().RemoveLife();
        eggLife--;
        FindObjectOfType<AudioManager>().Play("Shatter Egg");
        Debug.Log("Damage");

        //Update the brake layer to see the damage in the gg
        GetComponentInChildren<BrakeLayerController>().UpdateBrakeLayer();
        //----------------------------------------------------
        //reset the higher position
        higherPosition = transform.position.y;
        //--------------------------
    }

    public bool canDamage;
    public void SetCanDamage(bool a)
    {
        canDamage = a;
    }
    private void DamageController()
    {
        //when is not grounded, you can damage the egg on the fall
        //this way you can damage the egg just one time
        if (!GetComponent<CollisionDetector>().GetGrounded())
        {
            canDamage = true;
        }
    }

    public void Die()
    {
        if (!eggIsDead)
        {
            //Stop the Music
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().Stop("Gameplay");
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().Stop("Ambient");
            //----------------------------------------------------------------------------------
            //Play the Lose Music
            //GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("Lose");
            //-------------------------------------------
            

            //Eliminate the ui eggs
            GameObject.Find("Lifes").GetComponent<EggLifeUI>().SetAllFalse();
            //---------------------------------------------------------------

            //Set the cascaras obtained
            //Is not working anymore
            //GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().SetCascarasObtained();
            //The method knows how many cascaras give to the player.
            //----------------------------

            //Set the Braker layer to the last one
            GetComponentInChildren<BrakeLayerController>().DieLayer();
            //----------------------------------------

            //Eliminate the rigidbody and the colliders
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(GetComponent<CapsuleCollider2D>());
            //-----------------------------------------

            //Close the UI collectables life score
            var anims = GameObject.Find("UI").GetComponentsInChildren<Animator>();
            foreach (var anim in anims)
            {
                anim.SetBool("out", true);
            }
            //----------------------------------------

            //Show the video ad
            GameObject.Find("AdsManager").GetComponent<AdsManager>().ShowDieVideo();
            //--------------------------

            //Close the big leafs
            StartCoroutine(CloseLeaf());
            //----------------------------------------
            
            //Load new Scene
            StartCoroutine(LoadSceneAfterDie());
            //------------------------------------
            
            //to run this metho only once
            eggIsDead = true;
        }
        
    }
    
    IEnumerator LoadSceneAfterDie()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(1f);//with music is 1.4, whitout it is 0.6
        SceneManager.LoadScene("PlayResults");
    }
    
    IEnumerator CloseLeaf()
    {
        yield return new WaitForSeconds(0.4f);//with music is 0.6, whitout it is 0
        //Close the big leafs
        GameObject.Find("Leaf Pass").GetComponent<Animator>().SetBool("out", false);
        GameObject.Find("Leaf Pass").GetComponent<Animator>().SetBool("in", true);
    }
    
    private void VerifyEggLife()
    {
        if (eggLife < 0 || eggLife == 0)
        {
            Die();
        }
    }
    #endregion


}
