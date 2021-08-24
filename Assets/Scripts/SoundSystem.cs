using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;

    public AudioClip audioSpeedUp;
    public AudioClip audioBrake;
    public AudioClip audioMachineGun;
    public AudioClip audioCannon;
    public AudioClip audioTurbo;

    //para áñadir mas fuentes de sonido
    public AudioSource audioSource;
    public AudioSource audioSource2;

    //no se toca put* el que toca
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
    public void PlaySpeedUp()
    {
        PlayAudioClip(audioSpeedUp);
    }
    public void PlayBrake()
    {
        PlayAudioClip(audioBrake);
    }
    public void PlayShoot()
    {
        PlayAudioClip(audioMachineGun);
    }
    public void PlayCannon()
    {
        PlayAudioClip2(audioCannon);
    }

    public void PlayTurbo()
    {
        PlayAudioClip2(audioTurbo);
    }
    //AUDIO SOURCE

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


    //esto no se toca es del singlenton
    private void OnDestroy()
    {
        if (SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
