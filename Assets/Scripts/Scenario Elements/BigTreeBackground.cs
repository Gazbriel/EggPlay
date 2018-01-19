using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTreeBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Random.Range(-3f, 3f), transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
