using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class audiomanager : MonoBehaviour
{
    public static audiomanager instance { get; private set;}
    [SerializeField] private audio[] audios; 
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.clip;
            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
        }
    }

    void Start()
    {
        play("bg");
    }

    void dstopthebg()
    {
        stop("bg");
    }

    public void play(string name)
    {
        audio a = Array.Find(audios,audio => audio.name == name);
        if(a == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        a.source.Play();
    }

    public void stop(string name)
    {
        audio a = Array.Find(audios,audio => audio.name == name);
        if(a == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        a.source.Stop();
    }
}
