using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        lasHightGrounded = transform.position.y;

    }

    // Update is called once per frame
	void Update () {
        //verify if is far from ground
        CheckGrounded();
        //-----------------------

        SetCanJump();
    }

    private void SetCanJump()
    {
        if (grounded)
        {
            GameObject.Find("Slide Detector").GetComponent<SwipeDetector>().SetCanJump(true);
            GameObject.Find("Slide Detector").GetComponent<SwipeDetectorVelocityController>().SetCanJump(true);
        }
        else
        {
            GameObject.Find("Slide Detector").GetComponent<SwipeDetector>().SetCanJump(false);
            GameObject.Find("Slide Detector").GetComponent<SwipeDetectorVelocityController>().SetCanJump(false);
        }
    }
    

    

    #region Is Grounded or not (can Jump or not)
    public bool grounded;
    public void SetGrounded(bool a)
    {
        grounded = a;
    }
    public bool GetGrounded()
    {
        return grounded;
    }
    public float lasHightGrounded;
    public float hightAmplitude;//to detect the collision with safe ground

    //Constantly checking if is grounded
    private void CheckGrounded()
    {
        if (Mathf.Abs(gameObject.transform.position.y - lasHightGrounded) > hightAmplitude)
        {
            grounded = false;
        }

    }

    //if it collide with an object, the compare the hights
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //it helps to know the hits with the ground to certain hight
        if (collision.gameObject.tag == "Safe Ground")
        {
            if (GetComponent<Rigidbody2D>().velocity.y < 2)
            {
                grounded = true;
                lasHightGrounded = gameObject.transform.position.y;
                
                //Do damage
                GetComponent<LifeDuration>().Damage();
                //Debug.Log("Collision velocity "+GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        Debug.Log("The eagle has landed");

        #region Collision with Side walls //Dont work yet
        if (collision.gameObject.tag == "Side Walls")
        {
            if (collision.relativeVelocity.x > GetComponent<LifeDuration>().sideVelocityDamage || collision.relativeVelocity.x < -GetComponent<LifeDuration>().sideVelocityDamage)
            {
                //Do damage
                GetComponent<LifeDuration>().DoDamage();
                //Debug.Log("Collision velocity "+GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        #endregion

    }
    #endregion

}
