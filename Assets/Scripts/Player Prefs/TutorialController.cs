using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	}
    public Vector3 offset;
    private void OnMouseDown()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        PlayerPrefs.SetInt("doneTutorial", 1);
        GetComponent<Animator>().SetBool("out", true);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Main");
    }
}
