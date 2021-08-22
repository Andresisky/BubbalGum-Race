using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;

    public AudioClip audioClipAcelera;
    public AudioClip audioFrena;
    public AudioClip audioMachineGun;
    public AudioClip audioCanon;
    public AudioClip audioTurbo;
    public AudioSource audioSource;
    public AudioSource audioSource2;

    private void Awake()
    {
        if (SoundSystem.instance == null)//si no tiene nada asigando se lo asigna 
        {
            SoundSystem.instance = this;

        }
        else if (SoundSystem.instance != this)//si tiene asigando y no es la instancia se destuye
        {
            Destroy(gameObject);

        }
    }
    //Ponemos un metodo con el nombre y el audiosource para anadir
    public void PlayAcelera()
    {
        PlayAudioClip(audioClipAcelera);
    }
    public void PlayFreno()
    {
        PlayAudioClip(audioFrena);
    }
    public void PlayDisparo()
    {
        PlayAudioClip(audioMachineGun);
    }
    public void PlayCanon()
    {
        PlayAudioClip2(audioCanon);
    }

    public void PlayTurbo()
    {
        PlayAudioClip2(audioTurbo);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    private void PlayAudioClip2(AudioClip audioClip2)
    {
        audioSource2.clip = audioClip2;
        audioSource2.Play();
    }

    private void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
