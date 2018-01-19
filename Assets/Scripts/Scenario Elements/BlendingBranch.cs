using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendingBranch : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        a = Random.Range(0, 2);
        SetPosition();
        GenerateCollectable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float offSet;
    private int a;
    #region Set Position random, left or right.
    private void SetPosition()
    {
        if (a == 0)
        {

            Debug.Log("Placed ramdom");
            gameObject.transform.position = new Vector3(-13.2f, transform.position.y + offSet, transform.position.z);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            gameObject.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, -transform.rotation.z, transform.rotation.w);
        }
        else
        {
            gameObject.transform.position = new Vector3(13.2f, transform.position.y + offSet, transform.position.z);
        }

    }

    #endregion

    //a == 0 is left
    public int probability;
    public Vector3 position;
    private void GenerateCollectable()
    {
        GameObject collectable = GameObject.Find("Level Generator").GetComponent<LevelGenerator>().collectable;
        int value = Random.Range(0, 100);
        if (value < probability)
        {
            // update hight value
            position.y += transform.position.y;
            //---------------
            switch (a)
            {
                case 0:
                    Instantiate(collectable, position, collectable.transform.rotation);
                    break;
                case 1:
                    position.x = -position.x;
                    Instantiate(collectable, position, collectable.transform.rotation);
                    break;
            }
        }
    }


}
