using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour {

    #region Dont Destroy the Object
    //esto es para hacer que no haya mas de un audio manager en la escenna
    public static PlayerPreferences instance;
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
    }
    #endregion

    #region Reset Best Score && EggsCollected
    public bool resetBest;
    private void ResetBest()
    {
        if (resetBest)
        {
            PlayerPrefs.SetInt("best", 0);
        }
    }
    public bool resetEggsCollected;
    private void ResetEggsCollected()
    {
        if (resetEggsCollected)
        {
            //needed to put the name of every egg here.
            PlayerPrefs.SetInt("Egg 1", 0);
            PlayerPrefs.SetInt("Egg 2", 0);
            PlayerPrefs.SetInt("Egg 3", 0);
            PlayerPrefs.SetInt("Egg 4", 0);
            PlayerPrefs.SetInt("Egg 5", 0);
        }
    }
    private void ResetTutorial()
    {
        if (resetTutorial)
        {
            PlayerPrefs.SetInt("doneTutorial", 0);
        }
    }
    #endregion

    // Use this for initialization
    void Start () {
        LoadScores();

        //this only works if the boolean is active
        ResetBest();
        ResetEggsCollected();
        ResetCollectables();
        ResetTutorial();
        //-----------------------------------------

        //Set the first egg alwways available (0 is false, 1 is true)
        PlayerPrefs.SetInt("Egg 1", 1);
        //-----------------------------------------------------------
    }

    public int bestscore;
	// Update is called once per frame
	void Update () {
		bestscore = PlayerPrefs.GetInt("best");
    }

    //Load Scores
    private void LoadScores()
    {
        //not matter that the current score 
        //does not turn cero after the firs game,
        //it will wen the otre game start.
        currentScore = 0;
        
    }

    #region Set the Score
    public int currentScore;
    public int GetCurrentScore()
    {
        return currentScore;
    }
    public void SetCurrentScore(int score)
    {
        currentScore = score;
        Debug.Log("Current Score " + currentScore);
        //if (currentScore > PlayerPrefs.GetInt("best"))
        //{
        //    SetBestScore();
        //}
    }
    private void SetBestScore()
    {
        //Debug.Log("New Best " + currentScore);
        //PlayerPrefs.SetInt("best", currentScore);

        //send the best score to leaderboard
        //GameObject.Find("Main Camera").GetComponent<LadderboardController>().ReportScore(currentScore);
        //-----------------------------------
    }
    #endregion
    
    //#region Set the cascaras
    //public bool resetCascaras;
    //private int cascarasObtained;
    //private void ResetCascaras()
    //{
    //    if (resetCascaras)
    //    {
    //        PlayerPrefs.SetInt("cascaras", 0);
    //    }
    //}
    //public int GetCascarasObtained()
    //{
    //    return cascarasObtained;
    //}
    //public void SetCascarasObtained()
    //{
    //    if (currentScore < 5)
    //    {
    //        cascarasObtained = 2;
    //    }
    //    else// > 5
    //    {
    //        cascarasObtained = (int)(2 + Mathf.Sqrt(currentScore));
    //    }
        
    //    PlayerPrefs.SetInt("cascaras", PlayerPrefs.GetInt("cascaras") + cascarasObtained);
    //    Debug.Log("cascaras " + PlayerPrefs.GetInt("cascaras"));
        
    //}
    //#endregion

    #region Set the Collectables (Pluma)
    public bool resetCollectables;
    public int collectablesObtained;
    private void ResetCollectables()
    {
        if (resetCollectables)
        {
            PlayerPrefs.SetInt("collectables", 0);
        }
    }
    public void ResetCollectablesObtained()
    {
        collectablesObtained = 0;
    }
    public int GetCollectablesObtained()
    {
        return collectablesObtained;
    }
    public void AddCollectablesObtained(int a)
    {
        //add to collectables obtained
        collectablesObtained += a;
        //add to collectables
        AddCollectables(a);
    }
    public void AddCollectables(int a)
    {
        //add the a amount of collectables to the existing allready.
        PlayerPrefs.SetInt("collectables", PlayerPrefs.GetInt("collectables") + a);
    }
    #endregion

    #region Eggs Select
    // Player.Pref "egg"  //the egg that the player is using.
    public GameObject egg;

    //private void LoadEgg()
    //{
    //this method later will load the egg that the player was using during the las time he layed the game
    //}

    public void SetEgg(GameObject egg)
    {
        this.egg = egg;
        Debug.Log("The egg is seted to " + egg.name);
    }
    public GameObject GetCurrentEgg()
    {
        return egg;
    }
    #endregion

    #region Tutorial
    public bool resetTutorial;

    #endregion

    public bool triedLogin;
    public void SetTriedLogin(bool a)
    {
        triedLogin = a;
    }

}
