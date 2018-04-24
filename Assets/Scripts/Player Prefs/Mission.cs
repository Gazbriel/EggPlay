using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //para que salga la lista de elementos en el inspector de unity
public class Mission{

    public string eggName;
    public Sprite image;
    public bool trueHigh;
    public int high;
    public bool trueCollectables;
    public int collectables;
    public int reward;


    public bool GetMissionStatus(string eggName)
    {
        if (this.eggName == eggName)
        {
            if (trueHigh && trueCollectables && CheckCollectable() && CheckHigh())
            {
                return true;
            }
            if (trueHigh && CheckHigh())
            {
                return true;
            }
            if (trueCollectables && CheckCollectable())
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckHigh()
    {
        if (GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().GetCurrentScore() >= high)
        {
            //mission acomplished
            return true;
        }
        else
        {
            //mission not acomplished
            return false;
        }
    }
    private bool CheckCollectable()
    {
        if (GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().GetCollectablesObtained() >= collectables)
        {
            //mission acomplished
            return true;
        }
        else
        {
            //mission not acomplished
            return false;
        }
    }
}
