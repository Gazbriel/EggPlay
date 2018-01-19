using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private bool touched;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!touched)
        {
            if (collision.gameObject.tag == "Egg")
            {
                //add the collectable to the egg collectables, and to the collectable getted on play
                GameObject.FindGameObjectWithTag("Player Prefs").GetComponent<PlayerPreferences>().AddCollectablesObtained(1);
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().Play("GetCollectable");
                touched = true;
                StartCoroutine(DestroyAfterAnimation());
            }
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        GetComponent<Animator>().SetBool("out", true);
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
