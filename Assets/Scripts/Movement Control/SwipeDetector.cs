using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour {
    //4 directions

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

    public float circleLimitThrow;
    public float underCircleLimitThrow;

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
        

        #region Calculate distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.GetMouseButton(0))
            {
                //Debug.Log(swipeDelta);
                Vector2 mouseUp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                swipeDelta = mouseUp - startTouch;
                //Debug.Log(startTouch);
                //Debug.Log(swipeDelta);
            }
        }
        #endregion

        

    }

    private void DoAction()
    {
        //verify if can do the action and there is a rigidboy attached to the egg
        if (canJump && GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>() != null)
        {
            

            //if swipedelta is bigger than the limit and if you pointed up
            if (swipeDelta.magnitude > circleLimitThrow && swipeDelta.y > 0)
            {
                //Stop the movement of the Egg
                GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().velocity = new Vector3();
                //--------------------------------

                Debug.Log("Did Throw Max");
                //do the action with swipeMagnitude.normalized
                GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().AddForce(swipeDelta.normalized * circleLimitThrow * power);
                AddTorque();

                // Play sound jump
                //Debug.Log("Played jump sound");
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayRandom(new string[3] { "Jump1", "Jump2", "Jump3" });
                //-------------------------

                //-----
                canJump = false;
                GameObject.FindGameObjectWithTag("Egg").GetComponent<CollisionDetector>().SetGrounded(false);
            }
            else if (swipeDelta.magnitude < circleLimitThrow && swipeDelta.magnitude > underCircleLimitThrow && swipeDelta.y > 0)
            {
                //Stop the movement of the Egg
                GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().velocity = new Vector3();
                //--------------------------------

                Debug.Log("Did Throw Between");
                GameObject.FindGameObjectWithTag("Egg").GetComponent<Rigidbody2D>().AddForce(swipeDelta * power);
                AddTorque();

                // Play sound jump -------------
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayRandom(new string[3] { "Jump1", "Jump2", "Jump3" });
                //------------------------------

                //-----
                canJump = false;
                GameObject.FindGameObjectWithTag("Egg").GetComponent<CollisionDetector>().SetGrounded(false);
            }
            
        }
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

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }


}
