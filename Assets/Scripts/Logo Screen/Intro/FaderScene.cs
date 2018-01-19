using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderScene : MonoBehaviour {

    public Texture2D fadeTexture;
    public float fadeSpeed;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;//-1= in    1 = out

    private void OnGUI()
    {
        //fade in and out
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //force value -1  1
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OneLevelWasLoad()
    {
        BeginFade(-1);
    }
}
