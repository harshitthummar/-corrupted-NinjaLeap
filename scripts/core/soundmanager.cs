using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public static soundmanager instance { get; private set; }
    private AudioSource source;


    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }
    public void playsound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
