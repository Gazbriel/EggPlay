using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectByDistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
        destoyDistance = 80;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        DestroyByDistance();
	}

    public float destoyDistance;

    private void DestroyByDistance()
    {
        if ((GameObject.FindGameObjectWithTag("Egg").transform.position.y - transform.position.y) > destoyDistance)
        {
            Destroy(this.gameObject);
        }
    }
    
}
