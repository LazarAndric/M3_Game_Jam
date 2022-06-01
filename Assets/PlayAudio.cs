using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource inGame;
    public AudioSource ADCactiv;
    public AudioSource basicAttack;
    public AudioSource shild;
    public AudioSource TANKactive;
    public AudioSource Ultimate;

    public static PlayAudio Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        inGame.Play();
    }

    public void PlaySound(AudioSource audio)
    {
        audio.Play();
    }
    public void StopSound(AudioSource audio)
    {
        audio.Stop();
    }

}
