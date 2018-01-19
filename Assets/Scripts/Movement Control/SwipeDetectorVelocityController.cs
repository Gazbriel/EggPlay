using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetectorVelocityController : MonoBehaviour {
    //Velocity Sensitive, not Distance.
    //4 directions

    private void Start()
    {
        touchTimeForce = maxTouchTimeForce;
    }

    private bool isDragging;
    private Vector2 startTouch, swipeDelta;
    public Vector2 GetStartTouch()
    {
        return startTouch;
    }
    #region canJump Variable and acces properties
    public bool canJump;
    public void SetCanJump(bool a)
    {
        canJump = a;
    }
    public bool GetCanJump()
    {
        return canJump;
    }
    #endregion

    [Header("Power of Throwing")]
    public float power;//power of throwing

    private void Update()
    {

        #region Inputs
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Finguer Up");
            DoAction();//verify if can do it
            isDragging = false;
            Reset();
        }
        #endregion

        UpdateTouchTime();
        SetGlobalForce();

        #region Calculate distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mouseUp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                swipeDelta = mouseUp - startTouch;
            }
        }
        #endregion
    }

    private void DoAction()
    {
        //verify if can do the action and there is a rigidboy attached to the egg
        if (canJump && GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>() != null && globalForce.magnitude > minGlobalForce && globalForce.y > 0)
        {
            Debug.Log("JUMPPPP");
            //Stop the movement of the Egg
            GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().velocity = new Vector3();
            //--------------------------------

            //do the action with Velocity
            GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().AddForce(globalForce);
            AddTorque();

            // Play sound jump
            //Debug.Log("Played jump sound");
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayRandom(new string[3] { "Jump1", "Jump2", "Jump3" });
            //-------------------------

            //-----
            canJump = false;
            GameObject.FindGameObjectWithTag("Egg").GetComponent<CollisionDetector>().SetGrounded(false);

        }
        //Reset the touch time force.
        ResetTime();
    }

    #region Egg Rotation
    [Header("Rotation Egg Torque Force (to the rigth)")]
    public float torqueForce;
    private void AddTorque()
    {
        //GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().AddTorque(-swipeDelta.x * torqueForce);
        if (swipeDelta.x < 0)
        {
            GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().AddTorque(torqueForce);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().AddTorque(-torqueForce);
        }

    }
    #endregion

    #region Time Controller
    // there is a max value that decresses when the key is pressed and that value is multiplied to the push force.
    public float minTouchTimeForce;
    public float maxTouchTimeForce;
    public float timeDereasseMultiplier;
    private float touchTimeForce;
    private void UpdateTouchTime()
    {
        if (Input.GetMouseButton(0) && touchTimeForce > minTouchTimeForce)
        {
            touchTimeForce -= Time.deltaTime*timeDereasseMultiplier;
        }
    }
    private void ResetTime()
    {
        touchTimeForce = maxTouchTimeForce;
    }

    #endregion

    #region General Force Controller
    public float maxGlobalForce;
    public float minGlobalForce;
    private Vector2 globalForce;
    private void SetGlobalForce()
    {
        //if the global force is too big,
        //set the global force to the maximum
        //else, set the current global force.
        globalForce = swipeDelta * power * touchTimeForce;
        if (globalForce.magnitude > maxGlobalForce)
        {
            globalForce = globalForce.normalized * maxGlobalForce;
        }
        if (globalForce.magnitude < minGlobalForce)
        {
            globalForce = globalForce.normalized * minGlobalForce;
        }
    }
    #endregion

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
