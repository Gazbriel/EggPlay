using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ChangeLevel()); ;

    }
    
	// Update is called once per frame
	void Update () {
        
	}

    public float timeToWait;
    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(timeToWait);
        float fadeTime = GameObject.Find("Fader").GetComponent<FaderScene>().BeginFade(1);
        Debug.Log("Found it");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Menu");
    }
}
