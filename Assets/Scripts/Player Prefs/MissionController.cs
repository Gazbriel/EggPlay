using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour {
    public Mission[] missions;
    // Use this for initialization
    void Start () {
        LoadLastMission();
        Debug.Log("the mission is " + mission);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //this method is call when inisialized the game, to load the mission
    private string mission;
    private void LoadLastMission()
    {
        mission = PlayerPrefs.GetString("mission");
        if (mission == "")
        {
            mission = "Egg 1";
        }
    }

    public void ChangeMission()
    {
        Debug.Log("Called Change Mission");
        int missionIndex = UnityEngine.Random.Range(0, missions.Length);
        PlayerPrefs.SetString("mission", missions[missionIndex].eggName);
        mission = PlayerPrefs.GetString("mission");
        Debug.Log("Mission Changed to " + mission);
    }

    public void Reward()
    {
        PlayerPrefs.SetInt("collectables", PlayerPrefs.GetInt("collectables") + GetCurrentMission().reward);
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("GetCollectable");
    }

    public bool CheckMissionAcomplished()
    {
        Mission m = GetCurrentMission();
        if (m.GetMissionStatus(mission))
        {
            //show the panel
            //GameObject.FindGameObjectWithTag("Mission Panel").SetActive(true);
            //GameObject.Find("Mission Panel").SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }

    public Mission GetCurrentMission()
    {
        Mission m = Array.Find(missions, mi => mi.eggName == mission);
        return m;
    }

    //public GameObject panel;


}
