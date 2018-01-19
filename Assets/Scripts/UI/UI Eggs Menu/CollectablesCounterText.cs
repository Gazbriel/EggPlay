using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesCounterText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = PlayerPrefs.GetInt("collectables").ToString();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Text>().text = PlayerPrefs.GetInt("collectables").ToString();
    }
}
