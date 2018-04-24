using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMissionPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject panel;
    public void ShowThePanel()
    {
        panel.SetActive(true);
        GameObject.FindGameObjectWithTag("Mission Panel").GetComponent<MissionPanelAnimation>().BeginShowMission();
    }
}
