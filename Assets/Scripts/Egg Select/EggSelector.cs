using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSelector : MonoBehaviour {

    #region Egg variables
    //The showed egg
    public GameObject eggShowed;
    //every tim a diffrent egg is showed, the objects destroys and another is created.
    //Specifing were the animation must enter. Left or right.

    //The pointer to the current egg on the list
    public int currentEgg;

    //The list of eggs
    public GameObject[] eggList;

    #endregion

    // Use this for initialization
    void Start () {
        currentEgg = 0;
        ShowEgg("inRight");

    }


    #region Show the eggs and change them
    private void ShowEgg(string entryDirection)
    {
        //create the showed egg and gives it the image of the corresponding egg
        GameObject egg = Instantiate(eggShowed);
        egg.GetComponent<SpriteRenderer>().sprite = eggList[currentEgg].GetComponent<SpriteRenderer>().sprite;

        if (entryDirection != "")
        {
            egg.GetComponent<Animator>().SetBool(entryDirection, true);
        }
    }

    public void NextRight()
    {
        if (currentEgg < eggList.Length-1 && GameObject.FindGameObjectsWithTag("Egg Showed").Length == 1)
        {
            //do
            currentEgg++;
            //destory the older
            GameObject.FindGameObjectWithTag("Egg Showed").GetComponent<EggShowed>().Die("left");
            //create a new one
            ShowEgg("inRight");
            //set where to entry
            
        }
    }

    public void NextLeft()
    {
        if (currentEgg > 0 && GameObject.FindGameObjectsWithTag("Egg Showed").Length == 1)
        {
            //do
            currentEgg--;
            //destory the older
            GameObject.FindGameObjectWithTag("Egg Showed").GetComponent<EggShowed>().Die("right");
            //create a new one
            ShowEgg("inLeft");
        }
    }

    #endregion

}
