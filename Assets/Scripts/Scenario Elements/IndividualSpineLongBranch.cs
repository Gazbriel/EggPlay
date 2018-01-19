using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualSpineLongBranch : MonoBehaviour {


    public string position;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnSpine());
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private IEnumerator SpawnSpine()
    {
        yield return new WaitForSeconds(0.1f);
        switch (position)
        {
            case "left":
                if (!GetComponentInParent<LongBranchSpines>().GetSpineLeft())
                {
                    Debug.Log("Left false");
                    //enabled = false;
                    GenerateCollectable("left");
                    Destroy(this.gameObject);
                }
                break;

            case "center":
                if (!GetComponentInParent<LongBranchSpines>().GetSpineCenter())
                {
                    Debug.Log("Center false");
                    //enabled = false;
                    GenerateCollectable("center");
                    Destroy(this.gameObject);
                }
                break;

            case "right":
                if (!GetComponentInParent<LongBranchSpines>().GetSpineRight())
                {
                    Debug.Log("Right false");
                    //enabled = false;
                    GenerateCollectable("right");
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    private bool done;
    public int probability;
    public Vector3 collectablePosition;
    private void GenerateCollectable(string position)
    {
        if (!done)
        {
            //Set the position
            switch (position)
            {
                case "left":
                    collectablePosition.x -= 6;
                    break;
                case "right":
                    collectablePosition.x += 5;
                    break;
                case "center":
                    collectablePosition.x -= 1;
                    break;
            }
            //---------------------

            int value = Random.Range(0, 100);
            if (value < probability)
            {
                GameObject pluma = GameObject.Find("Level Generator").GetComponent<LevelGenerator>().collectable;
                //happen, generate
                Instantiate(pluma, collectablePosition + gameObject.transform.position, pluma.transform.rotation);
            }
            done = true;
        }
    }

}
