using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EggLifeUI : MonoBehaviour {
    
    public GameObject[] lifes;
	// Use this for initialization
	void Start () {
        //eggLifesCounter = GameObject.FindGameObjectWithTag("Egg").GetComponent<LifeDuration>().GetEggLife();
        SetAllFalse();
        //CreateStartingLifes();
    }

    public void SetAllFalse()
    {
        for (int i = 0; i < lifes.Length; i++)
        {
            //lifes[i].SetActive(false);
            lifes[i].GetComponent<Animator>().SetBool("out", true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private int eggLifesCounter;
    public void SetEggLifesCounter(int a)
    {
        eggLifesCounter = a;
    }
    //this method is call from the egg life
    public void CreateStartingLifes()
    {
        for (int i = 0; i < eggLifesCounter; i++)
        {
            //lifes[i].SetActive(true);
            lifes[i].GetComponent<Animator>().SetBool("out", false);
            lifes[i].GetComponent<Animator>().SetBool("in", true);
        }
    }

    public void RemoveLife()
    {
        //lifes[i].SetActive(false);
        lifes[eggLifesCounter-1].GetComponent<Animator>().SetBool("in", false);
        lifes[eggLifesCounter-1].GetComponent<Animator>().SetBool("out", true);
        eggLifesCounter--;
    }
}
