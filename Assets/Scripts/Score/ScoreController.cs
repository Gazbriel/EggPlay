using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Starting position
        highestEggPosition = 0;
        //-------------------------
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHighestEggPosition();
    }

    #region Higest Position
    private int highestEggPosition;
    private void UpdateHighestEggPosition()
    {
        if (GameObject.FindGameObjectWithTag("Egg").transform.position.y > highestEggPosition)
        {
            highestEggPosition = (int)GameObject.FindGameObjectWithTag("Egg").transform.position.y;
            SetCurrentScore();
        }
    }

    private void SetCurrentScore()
    {
        GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().SetCurrentScore(highestEggPosition/10);
    }
    #endregion

    

}
