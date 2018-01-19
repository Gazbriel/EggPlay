using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().currentScore.ToString();
        if (GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().currentScore > PlayerPrefs.GetInt("best"))
        {
            PlayerPrefs.SetInt("best", GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().currentScore);
            //Sign in
            GameObject.Find("Main Camera").GetComponent<LadderboardController>().SignIn();
            //send the best score to leaderboard
            GameObject.Find("Main Camera").GetComponent<LadderboardController>().ReportScore(GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().currentScore);
            //-----------------------------------
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
