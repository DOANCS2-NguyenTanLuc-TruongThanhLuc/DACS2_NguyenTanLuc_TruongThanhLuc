using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource MusicAudioSource;
    public AudioSource VfxAudioSource;

    public AudioClip MusicClip;

    void Start()
    {
        MusicAudioSource.clip = MusicClip;
        MusicAudioSource.Play();
    }
}
