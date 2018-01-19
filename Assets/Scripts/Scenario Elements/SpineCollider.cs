using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpineCollider : MonoBehaviour {

    //velocity to detect that the egg is not moving or is quiet
    public float detectionVelocity;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Egg" && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < detectionVelocity)
        {
            //Code for braking the Egg
            FindObjectOfType<AudioManager>().Play("Shatter Egg");
            GameObject.FindGameObjectWithTag("Egg").GetComponent<LifeDuration>().Die();
        }
    }
}
