using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeLayerController : MonoBehaviour {

    public Sprite break1;//the less damage
    public Sprite break2; //the medium damage
    public Sprite break3; //the bigger damage


    private int starterEggLife;
	
	public void SetStarterLife(int a)
    {
        starterEggLife = a;
    }
	public void UpdateBrakeLayer()
    {
        if (GetComponentInParent<LifeDuration>().GetEggLife() > (2*(starterEggLife/3)))
        {
            //More than 2 therds of life (low damage)
            GetComponent<SpriteRenderer>().sprite = break1;
        }
        if (GetComponentInParent<LifeDuration>().GetEggLife() > ((starterEggLife / 3)))
        {
            //More than 1 therds of life (medium damage)
            GetComponent<SpriteRenderer>().sprite = break2;
        }
        else
        {
            //Less than 1 therds of life (Big damage)
            GetComponent<SpriteRenderer>().sprite = break3;
        }
    }
    public void DieLayer()
    {
        GetComponent<SpriteRenderer>().sprite = break3;
    }

    
}
