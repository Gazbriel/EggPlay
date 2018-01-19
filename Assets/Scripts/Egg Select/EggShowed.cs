using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggShowed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die(string direccion)
    {
        GetComponent<Animator>().SetBool(direccion, true);
        StartCoroutine(DeleteTheObject());
    }


    public float destroyTime;
    IEnumerator DeleteTheObject()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
