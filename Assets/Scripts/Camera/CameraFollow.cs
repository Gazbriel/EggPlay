using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        //just to find the egg
        FindEgg();
        //------------------------

        Vector3 desirePosition = new Vector3(0, target.position.y + offset.y, -10);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
        transform.position = smoothedPosition;

        //the same but only with y axe
         

        //transform.LookAt(target); //para mirar siempre al jugador
    }

    #region Find the Egg on Screen
    private bool founded;
    private void FindEgg()
    {
        if (GameObject.FindGameObjectWithTag("Egg") != null && !founded)
        {
            target = GameObject.FindGameObjectWithTag("Egg").transform;
            founded = true;
        }
        
    }
    #endregion
}
