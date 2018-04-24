using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPanelAnimation : MonoBehaviour {

    public GameObject closeButton;
    public GameObject skippButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginMissionAcomplished()
    {
        //Reward
        GameObject.Find("Missions").GetComponent<MissionController>().Reward();
        //Change Mission
        Debug.Log("Changing mision...");
        GameObject.Find("Missions").GetComponent<MissionController>().ChangeMission();
    }
    public void BeginShowMission()
    {
        closeButton.SetActive(true);
        skippButton.SetActive(true);
    }


    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
