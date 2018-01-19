using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour {

    #region Dont Destroy the Object
    //esto es para hacer que no haya mas de un audio manager en la escenna
    public static AdsManager instance;
    //------------------------------------
    private void Awake()
    {
        //para que no haya mas de un audio manager en la escena
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //-----------------------------------------------------
        DontDestroyOnLoad(gameObject);

        //---------
    }
    #endregion

    #region Get more collectables in egg menu scene
   
    public void ShowAdRewardVideoEggsMenu()
    {
        if (Advertisement.IsReady())
        {
            SetRewardInteractable(false);
            //the result at the end is for bein called the method below
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResultEggsMenu });
        }
    }
    //----------------
    //public float secondsToActivate;
    public void SetRewardInteractable(bool a)
    {
        GameObject.Find("RewardVideo").GetComponent<Button>().interactable = a;
    }
    //private void UpdateInteractable()
    //{
    //    if (!GameObject.Find("RewardVideo").GetComponent<Button>().interactable)
    //    {
    //        if (secondsToActivate < 0)
    //        {
    //            //set true
    //            GameObject.Find("RewardVideo").GetComponent<Button>().interactable = true;
    //            secondsToActivate = 20;
    //        }
    //        else
    //        {
    //            //keep counting down
    //            secondsToActivate -= Time.deltaTime;
    //        }
    //    }
    //}
    //private void FixedUpdate()
    //{
    //    if (GameObject.Find("RewardVideo") != null)
    //    {
    //        UpdateInteractable();
    //    }

    //}
    //--------------------------------------------

    private void HandleAdResultEggsMenu(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                //not conection internet
                break;
            case ShowResult.Skipped:
                //hey, you skeep the add
                break;
            case ShowResult.Finished:
                //reward Player
                PlayerPrefs.SetInt("collectables", PlayerPrefs.GetInt("collectables") + 10);
                SetRewardInteractable(true);
                break;
            default:
                break;
        }
    }
    #endregion

    #region Get normal video when the player die 5 times

    public int dieTimesStablish;
    private int dieCounter;

    public void ShowDieVideo()
    {
        //diedOnce = false;//this reset the die once and can show the messege again(video to continue)
        if (dieCounter == dieTimesStablish - 1)
        {
            if (Advertisement.IsReady())
            {
                //Pause the game
                Time.timeScale = 0;
                //--------------------------
                //the result at the end is for bein called the method below
                Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResultDieVideo });
            }
            dieCounter = 0;
        }
        else
        {
            dieCounter++;
        }
        
    }

    private void HandleAdResultDieVideo(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                //not conection internet
                Time.timeScale = 1;
                break;
            case ShowResult.Skipped:
                //hey, you skeep the add
                Time.timeScale = 1;
                break;
            case ShowResult.Finished:
                //reward Player
                Time.timeScale = 1;
                break;
            default:
                break;
        }
    }
    #endregion

    #region Watch a video to continue
    //private bool diedOnce;
    //public int scoreToShowVideoToContinue;
    //public void ShowAdRewardToContinue()
    //{
    //    if (!diedOnce && GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().GetCurrentScore() > scoreToShowVideoToContinue)
    //    {
    //        if (Advertisement.IsReady())
    //        {
    //            //the result at the end is for bein called the method below
    //            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResultToContinue });
    //        }
    //    }
    //}

    //public int upInYAXIS;
    //private void HandleAdResultToContinue(ShowResult result)
    //{
    //    GameObject branch = GameObject.Find("Long Branch(Clone)");
    //    switch (result)
    //    {
    //        case ShowResult.Failed:
    //            //not conection internet
    //            break;
    //        case ShowResult.Skipped:
    //            //hey, you skeep the add
    //            //while (!branch)
    //            //{
    //            //    GameObject.FindGameObjectWithTag("Egg").transform.position = new Vector3(0, GameObject.FindGameObjectWithTag("Egg").transform.position.y + upInYAXIS, 0);
    //            //    branch = GameObject.Find("Long Branch(Clone)");
    //            //}
    //            //GameObject.FindGameObjectWithTag("Egg").transform.position = new Vector3(0, branch.transform.position.y + 10, 0);
    //            //GameObject.FindGameObjectWithTag("Egg").GetComponent<LifeDuration>().LoadEgg();
    //            //break;
    //        case ShowResult.Finished:
    //            //reward Player
    //            GameObject.Find("Lifes").GetComponent<EggLifeUI>().SetEggLifesCounter(1);
    //            GameObject.Find("Lifes").GetComponent<EggLifeUI>().CreateStartingLifes();
    //            while (!branch)
    //            {
    //                GameObject.FindGameObjectWithTag("Egg").transform.position = new Vector3(0, GameObject.FindGameObjectWithTag("Egg").transform.position.y + upInYAXIS, 0);
    //                branch = GameObject.Find("Long Branch(Clone)");
    //            }
    //            GameObject.FindGameObjectWithTag("Egg").transform.position = new Vector3(0, branch.transform.position.y + 10, 0);
    //            GameObject.FindGameObjectWithTag("Egg").GetComponent<LifeDuration>().LoadEgg();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    #endregion


}
