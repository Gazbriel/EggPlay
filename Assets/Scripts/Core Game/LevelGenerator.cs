using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CreateStart();

        //Create Banner
        //GameObject.Find("AdsManager").GetComponent<AdManager>().ShowBanner();
        //--------------------

        //------Play Music-------------------------------------------------------------
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("Gameplay");
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("Ambient");
        //--------------------------------------------------------------------------------

        //Intantiate Tutorial
        //GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().ShowTutorial();
        //--------------------------
    }



    // Update is called once per frame
    void Update () {
        //GenerateCollectable();

        if (GameObject.FindGameObjectWithTag("Egg") != null)
        {
            if ((lastElementPositionY - GameObject.FindGameObjectWithTag("Egg").transform.position.y) < drawingDistance)
            {
                SelectElement();
            }
            if ((lastBackgroundPositionY - GameObject.FindGameObjectWithTag("Egg").transform.position.y) < drawingDistance)
            {
                GenerateBackgound();
            }
        }
	}

    #region Game Elements

    //Player
    public GameObject egg;

    //Collectables
    public GameObject collectable;

    //Gameplay grounds
    public GameObject strongBranch;
    public GameObject strongBrachSpine;
    public GameObject longBranch;
    public GameObject longBranchSpine;
    public GameObject blendingBranch;

    //The Backgrounds adn sidegrounds
    public GameObject sideTreeLeft;
    public GameObject sideTreeRight;
    public GameObject backgroundTree;
    public GameObject sky;
    #endregion


    //La idea 
    //es hacer aparecer aleatoriamente (con ciertas probabilidades)
    //los distintos elementos
    //siempre apareciendo a una misma distancia uno de otors
    //pero a lados distintos.
    //cada elemento en su constructor se inicializará en un lado u otro
    //Desde este script solo se controla cuál aparece.
    //Habrá otro script que los elimine o puede ser el mismo script constructor que los elimine---
    //con alguna condición, como que la camara le pasa por el lado o algo así.

    public float distanceBetweenObjects;
    public float drawingDistance;

    #region Creating the starting elements
    private void CreateStart()
    {
        Instantiate(longBranch, new Vector3(-5, 0, 0), longBranch.transform.rotation);
        //here the egg is taken from the player preferences
        Instantiate(GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().GetCurrentEgg(), new Vector3(0, 1, 0), egg.transform.rotation);
        lastElementPositionY = 0;

        //this methods calls need to be changed to a more progressive one
        //were the game gets harder and harder each time you go up
        //but for now is just this
        SelectElement();

        //creating the backgrounds
        Instantiate(sky, new Vector3(sky.transform.position.x, lastBackgroundPositionY, sky.transform.position.z), sky.transform.rotation);
        Instantiate(backgroundTree, new Vector3(backgroundTree.transform.position.x, lastBackgroundPositionY , backgroundTree.transform.position.z), backgroundTree.transform.rotation);
        Instantiate(sideTreeLeft, new Vector3(sideTreeLeft.transform.position.x, lastBackgroundPositionY, sideTreeLeft.transform.position.z), sideTreeLeft.transform.rotation);
        Instantiate(sideTreeRight, new Vector3(sideTreeRight.transform.position.x, lastBackgroundPositionY, sideTreeRight.transform.position.z), sideTreeRight.transform.rotation);

        GenerateBackgound();
    }
    #endregion

    #region Generating new elements

    private int selectElement;
    private void SelectElement()
    {
        selectElement = Random.Range(0, 5);

        switch (selectElement)
        {
            case 0:
                Instantiate(longBranch, new Vector3(longBranch.transform.position.x, lastElementPositionY + distanceBetweenObjects, longBranch.transform.position.z), strongBranch.transform.rotation);
                break;

            case 1:
                Instantiate(longBranchSpine, new Vector3(longBranchSpine.transform.position.x, lastElementPositionY + distanceBetweenObjects, longBranchSpine.transform.position.z), strongBranch.transform.rotation);
                break;

            case 2:
                Instantiate(strongBranch, new Vector3(strongBranch.transform.position.x, lastElementPositionY + distanceBetweenObjects, strongBranch.transform.position.z), strongBranch.transform.rotation);
                break;

            case 3:
                Instantiate(strongBrachSpine, new Vector3(strongBrachSpine.transform.position.x, lastElementPositionY + distanceBetweenObjects, strongBrachSpine.transform.position.z), strongBranch.transform.rotation);
                break;

            case 4:
                Instantiate(blendingBranch, new Vector3(blendingBranch.transform.position.x, lastElementPositionY + distanceBetweenObjects, blendingBranch.transform.position.z), strongBranch.transform.rotation);
                break;
        }
        lastElementPositionY += distanceBetweenObjects;
    }

    private float lastElementPositionY;
    //private void Generate()
    //{
    //    //method in development, just testing.
    //    Debug.Log("Generated");
    //    Instantiate(strongBranch, new Vector3(strongBranch.transform.position.x, lastElementPositionY + distanceBetweenObjects, strongBranch.transform.position.z), strongBranch.transform.rotation);
    //    lastElementPositionY += distanceBetweenObjects;
    //}

    private float lastCollectablePosition;
    public void GenerateCollectable()
    {
        //if (GameObject.FindGameObjectsWithTag("Pluma").Length < 10)
        //{
        //    Instantiate(collectable, new Vector3(Random.Range(-7, 7), 4 + lastCollectablePosition + distanceBetweenObjects, 0), transform.rotation);
        //    lastCollectablePosition += distanceBetweenObjects;
        //}
        
    }
    #endregion

    #region Generate Backgrounds
    public float distanceBetweenBackground;
    private float lastBackgroundPositionY;
    private void GenerateBackgound()
    {
        Instantiate(sky, new Vector3(sky.transform.position.x, lastBackgroundPositionY + distanceBetweenBackground, sky.transform.position.z), sky.transform.rotation);
        Instantiate(backgroundTree, new Vector3(backgroundTree.transform.position.x, lastBackgroundPositionY + distanceBetweenBackground, backgroundTree.transform.position.z), backgroundTree.transform.rotation);
        Instantiate(sideTreeLeft, new Vector3(sideTreeLeft.transform.position.x, lastBackgroundPositionY + distanceBetweenBackground, sideTreeLeft.transform.position.z), sideTreeLeft.transform.rotation);
        Instantiate(sideTreeRight, new Vector3(sideTreeRight.transform.position.x, lastBackgroundPositionY + distanceBetweenBackground, sideTreeRight.transform.position.z), sideTreeRight.transform.rotation);
        lastBackgroundPositionY += distanceBetweenBackground;
    }
    #endregion
}
