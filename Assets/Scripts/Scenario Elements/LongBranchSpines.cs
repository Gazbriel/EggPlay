using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBranchSpines : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        spineLeft = true;
        spineCenter = true;
        spineRight = true;

        SetSpines();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Variables boolean
    private bool spineLeft;
    private bool spineCenter;
    private bool spineRight;

    public bool GetSpineLeft()
    {
        return spineLeft;
    }

    public bool GetSpineRight()
    {
        return spineRight;
    }

    public bool GetSpineCenter()
    {
        return spineCenter;
    }
    #endregion

    private int a;
    #region Set Position random, left or right.
    private void SetSpines()
    {
        a = Random.Range(0, 6);
        switch (a)
        {
            case 0:
                spineLeft = false;
                break;

            case 1:
                spineCenter = false;
                break;

            case 2:
                spineRight = false;
                break;

            case 3:
                spineLeft = false;
                spineCenter = false;
                break;

            case 4:
                spineLeft = false;
                spineRight = false;
                break;
            case 5:
                spineCenter = false;
                spineRight = false;
                break;
        }

    }

    #endregion


}
