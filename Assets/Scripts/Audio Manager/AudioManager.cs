using UnityEngine.Audio;
using UnityEngine;
//Esto es para poder buscar usando array.find
using System;
using UnityEngine.UI;
//-------------------------------------------

public class AudioManager : MonoBehaviour {
    //Esta clase contiene una lista de sounds y los ejecuta.
    //para ello se llama al metodo play y se le pasa el nombre del sound
    //

    public Sound[] sounds;

    //esto es para hacer que no haya mas de un audio manager en la escenna
    public static AudioManager instance;
    //------------------------------------

    //este metodo es llamado justo antes de Start()
    private void Awake()
    {
        //para que no haya mas de un audio manager en la escena
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //-----------------------------------------------------

        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            //esta linea de abajo es para agregar un audio source y poder manejar las propiedades
            //del sonido
            s.source = gameObject.AddComponent<AudioSource>();

            //Aqui le asigno las propiedades publicas que determino en el inspector al
            //AudioSource 
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public Sound GetSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound" + name + "not found");
        }
        return s;
    }
    public void Play(string name)
    {
        if (!mute)
        {
            //busca de entre los sounds, el que tenga como nombre name
            Sound s = GetSound(name);
            s.source.Play();
            s.isPlaying = true;
        }
    }

    public void PlayRandom(string[] sounds)
    {
        string soundToPlay = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        Play(soundToPlay);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound" + name + "not found");
            return;
        }
        s.source.Stop();
        s.isPlaying = false;
    }

    #region Mute
    public bool mute;
    public void Mute()
    {
        if (!mute)
        {
            mute = true;
            //is true and need to stop the music in the menu
            Stop("Menu Background Music");
        }
        else
        {
            mute = false;
            //is in the menu, and need to be play themusic of the menu
            Debug.Log("Playyyyy");
            Play("Menu Background Music");
        }
    }
    #endregion
}
