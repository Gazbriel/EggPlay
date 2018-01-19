using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckUnlockedEgg();

    }

    public void SetCurrentEgg()
    {
        if (PlayerPrefs.GetInt(GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().eggList[GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().currentEgg].name) == 1)
        {
            GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().SetEgg(GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().eggList[GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().currentEgg]);
            Debug.Log("Seted egg " + GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().GetCurrentEgg().name);
        }
        else
        {
            //Unlock code
            if (PlayerPrefs.GetInt("collectables") >= GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().eggList[GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().currentEgg].GetComponent<OtherStats>().collectableCost)
            {
                //Play sound effect Unlock
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("Unlock");
                //-------------------------------------
                //Remove collectables
                PlayerPrefs.SetInt("collectables", PlayerPrefs.GetInt("collectables") - GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().eggList[GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().currentEgg].GetComponent<OtherStats>().collectableCost);
                //----------
                //Save the egg by name
                PlayerPrefs.SetInt(GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().eggList[GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().currentEgg].name, 1);
            }
        }
    }

    #region Select Correct Image for the Button
    public Sprite unlockSprite;
    public Sprite selectSprite;
    public void CheckUnlockedEgg()
    {
        if (PlayerPrefs.GetInt(GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().eggList[GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().currentEgg].name) == 1)
        {
            //unlocked
            if (GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().eggList[GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().currentEgg] == GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().egg)
            {
                //Show the selected image
                GetComponent<Image>().sprite = selectSprite;
                GetComponent<Button>().interactable = false;
                GetComponentInChildren<Text>().text = "";
            }
            else
            {
                //get the unlocked (Select) image to the button
                //Debug.Log("Seted the select image");
                GetComponent<Image>().sprite = selectSprite;
                GetComponent<Button>().interactable = true;
                GetComponentInChildren<Text>().text = "";
            }

        }
        else
        {
            //locked
            //get the Unlock Image to the button
            GetComponent<Image>().sprite = unlockSprite;
            GetComponent<Button>().interactable = true;
            GetComponentInChildren<Text>().text = GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().eggList[GameObject.FindGameObjectWithTag("Eggs Selector").GetComponent<EggSelector>().currentEgg].GetComponent<OtherStats>().collectableCost.ToString();
        }
    }
    #endregion
}
