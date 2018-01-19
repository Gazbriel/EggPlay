using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesObtainedText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().GetCollectablesObtained().ToString();
        GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().ResetCollectablesObtained();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
