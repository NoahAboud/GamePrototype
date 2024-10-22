using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;


    [Header("-----Audio Source------")]
    public AudioClip Music;


    [Header("-----Audio Clip------")]
    public AudioClip Ost;



    private void Start()
    {
        musicSource.clip = Ost;
        musicSource.Play();
    }

}
