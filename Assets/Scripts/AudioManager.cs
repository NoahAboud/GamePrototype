using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Source------")]
    public AudioClip Music;
    public AudioClip Sfx;

    [Header("-----Audio Clip------")]
    public AudioClip Ost;
    public AudioClip Summon;
    public AudioClip Gun;
    public AudioClip Sword;
    public AudioClip Explosion;


    private void Start()
    {
        musicSource.clip = Ost;
        musicSource.Play();
    }
    
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
