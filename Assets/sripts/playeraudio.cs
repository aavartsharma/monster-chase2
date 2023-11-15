using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class playeraudio : MonoBehaviour
{
    [SerializeField] private AudioSource[] postoshoot;

    public void playaudio(int audionumber)
    {
        postoshoot[audionumber].Play();
    }
}