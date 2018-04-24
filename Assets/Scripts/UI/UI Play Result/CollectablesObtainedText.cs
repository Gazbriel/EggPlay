using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesObtainedText : MonoBehaviour {

    // Use this for initialization
    public GameObject panel;
	void Start () {
        GetComponent<Text>().text = GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().GetCollectablesObtained().ToString();
        //Call the mission
        if (GameObject.Find("Missions").GetComponent<MissionController>().CheckMissionAcomplished())
        {
            panel.SetActive(true);
            //Call the panel mission acomplished, not the show mission
            GameObject.FindGameObjectWithTag("Mission Panel").GetComponent<MissionPanelAnimation>().BeginMissionAcomplished();
            //GameObject.FindGameObjectWithTag("Mission Panel").GetComponent<MissionPanelAnimation>().BeginShowMission();
            //----------------------------------------------------------
        }
        //-----------------
        GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().ResetCollectablesObtained();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
