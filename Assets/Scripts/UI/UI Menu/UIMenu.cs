using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour {

    private void Start()
    {
        #region Background Music Play
        if (!FindObjectOfType<AudioManager>().GetSound("Menu Background Music").isPlaying)
        {
            FindObjectOfType<AudioManager>().Play("Menu Background Music");
        }
        #endregion
    }

    public float timeToWait;
    private bool play;// true if the game need to start
	public void PlayGame()
    {
        SetOutAnimations();
        if (PlayerPrefs.GetInt("doneTutorial") == 0)
        {
            tutorial = true;
        }
        else
        {
            play = true;
        }
    }

    private bool backToMenu;
    public void BackToMenu()
    {
        SetOutAnimations();
        backToMenu = true;
    }

    private bool eggMenu;
    public void GoToEggMenu()
    {
        SetOutAnimations();
        eggMenu = true;
    }

    public void SetMute()
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().Mute();
    }

    private void Update()
    {
        ChangeScene();
    }

    //For the tutorial 
    private bool tutorial;
    //----------------------------

    private void ChangeScene()
    {
        #region Play
        if (play)
        {
            if (timeToWait < 0)
            {
                //stop playn the music
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().Stop("Menu Background Music");
                //------------------------
                SceneManager.LoadScene("Main");
            }
            else
            {
                timeToWait -= Time.deltaTime;
            }
        }
        #endregion

        #region BackToMenu
        if (backToMenu)
        {
            if (timeToWait < 0)
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                timeToWait -= Time.deltaTime;
            }
        }
        #endregion

        #region EggMenu
        if (eggMenu)
        {
            if (timeToWait < 0)
            {
                SceneManager.LoadScene("EggsMenu");
            }
            else
            {
                timeToWait -= Time.deltaTime;
            }
        }
        #endregion

        #region Tutorial
        if (tutorial)
        {
            if (timeToWait < 0)
            {
                //stop playn the music
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().Stop("Menu Background Music");
                //------------------------
                SceneManager.LoadScene("Tutorial");
            }
            else
            {
                timeToWait -= Time.deltaTime;
            }
        }
        #endregion

    }

    #region Set Out the animations
    private void SetOutAnimations()
    {
        var anims = GetComponentsInChildren<Animator>();
        foreach (var anim in anims)
        {
            anim.SetBool("out", true);
        }
        if (GameObject.FindGameObjectWithTag("Egg Showed") != null)
        {
            GameObject.FindGameObjectWithTag("Egg Showed").GetComponent<Animator>().SetBool("right", true);
        }
    }
    #endregion
}
