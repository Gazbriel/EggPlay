using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StayAtEggPosition();
        SetTargetDirection();
        if (Input.GetMouseButtonDown(0))
        {
            startTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        /*startTouch = GameObject.Find("Slide Detector").GetComponent<SwipeDetector>().GetStartTouch()*/;
        SetTargetForce();
    }

    
    
    private void StayAtEggPosition()
    {
        transform.position = GameObject.FindGameObjectWithTag("Egg").transform.position;
    }

    public Vector2 startTouch;
    public Vector2 direction;
    public float angle;
    private void SetTargetDirection()
    {
        //Dont know how but it works jejejje
        direction = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - startTouch;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        //----------------------------------------------------------------------------------
    }

    public GameObject[] targets;
    private void SetTargetForce()
    {
        //the bigger the force, the more objects are enabled.
        Vector2 swipeDelta = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - startTouch;
        //--------------------------------------------
        //this make the marks dont show if the finguer is not touching the screen.
        if (!Input.GetMouseButton(0) || swipeDelta.y < 0)
        {
            foreach (var target in targets)
            {
                target.GetComponent<SpriteRenderer>().enabled = false;
            }
            return;
        }

        if (swipeDelta.magnitude > 2)
        {
            //show the target 1
            targets[0].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            //dont show the target
            targets[0].GetComponent<SpriteRenderer>().enabled = false;
        }
        //--------------------------------------------
        if (swipeDelta.magnitude > 4)
        {
            //show the target 2
            targets[1].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            //dont show the target
            targets[1].GetComponent<SpriteRenderer>().enabled = false;
        }
        //--------------------------------------------
        if (swipeDelta.magnitude > 6)
        {
            //show the target 3
            targets[2].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            //dont show the target
            targets[2].GetComponent<SpriteRenderer>().enabled = false;
        }
        //--------------------------------------------
        if (swipeDelta.magnitude > 8)
        {
            //show the target 4
            targets[3].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            //dont show the target
            targets[3].GetComponent<SpriteRenderer>().enabled = false;
        }
        //--------------------------------------------
        if (swipeDelta.magnitude > 10)
        {
            //show the target 5
            targets[4].GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            //dont show the target
            targets[4].GetComponent<SpriteRenderer>().enabled = false;
        }
        //--------------------------------------------
    }
}
