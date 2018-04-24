using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class LadderboardController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //GameObject startButton = GameObject.Find("startButton");
        //EventSystem.current.firstSelectedGameObject = startButton;

        // ADD Play Game Services init code here.
        //  ADD THIS CODE BETWEEN THESE COMMENTS

        // Create client configuration
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        // END THE CODE TO PASTE INTO START

        // ADD THESE LINES
        // Get object instances
        //signInButtonText =
        //    GameObject.Find("signInButton").GetComponentInChildren<Text>();
        //authStatus = GameObject.Find("authStatus").GetComponent<Text>();

        // ...
        //try log in silent, if not, try showing
        Debug.Log("Started GPGS");
        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
        //if you are on the main screen and you have not tried to log in, then do it
        if (menuScene && !GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().triedLogin)
        {
            SignIn();
            //set that you tried to log in once
            GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().SetTriedLogin(true);
        }
    }
    
    public bool menuScene;

    // Update is called once per frame
    void Update () {
		
	}

    public void SignIn()
    {
        Debug.Log("signInButton clicked!");
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        //else
        //{
        //    // Sign out of play games
        //    PlayGamesPlatform.Instance.SignOut();

        //    // Reset UI
        //    //signInButtonText.text = "Sign In";
        //    //authStatus.text = "";
        //}
    }

    // ADD THESE TWO LINES
    //private Text signInButtonText;
    //private Text authStatus;
    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("Signed in!");

            // Change sign-in button text
            //signInButtonText.text = "Sign out";
            //GameObject.Find("Cartel").GetComponentInChildren<Text>().text = "Signed";

            //// Show the user's name
            //authStatus.text = "Signed in as: " + Social.localUser.userName;
        }
        else
        {
            Debug.Log("Sign-in failed...");
            //GameObject.Find("Cartel").GetComponentInChildren<Text>().text = "Failed";
            //text.text = "Failed";
            // Show failure message
            //signInButtonText.text = "Sign in";
            //authStatus.text = "Sign-in failed";
        }
    }



    public void OnLeaderboardClick()
    {
        ReportScore(PlayerPrefs.GetInt("best"));
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            //GameObject.Find("Cartel").GetComponentInChildren<Text>().text = "Signed";
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            SignIn();
        }
        Debug.Log("Show leaderboard");
    }

    

    public void ReportScore(int score)
    {
        PlayGamesPlatform.Instance.ReportScore(score, GPGSIds.leaderboard_highscore, (bool success) =>
        {
            Debug.Log("Reported Score to Leaderboard " + success.ToString());
        });
    }
}
