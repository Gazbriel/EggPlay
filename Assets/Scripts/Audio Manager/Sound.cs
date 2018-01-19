using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable] //para que salga la lista de elementos en el inspector de unity

//esta es la clase sound
public class Sound{


    public string name;
    public AudioClip clip;
    public bool isPlaying;

    //----[Range(0f, 1f)]------le determina valor a volumen entre esos valores.
    [Range(0f, 1f)]
    public float volume;

    [Range(-3f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
    
   
}
