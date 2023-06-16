using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _popSound;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private AudioSource _boosterSound;

    public void PlayPopSound() {

        _popSound.Play();
    }

    public void PlayWinSound()
    {

        _winSound.Play();
    }

    public void PlayLoseSound()
    {

        _loseSound.Play();
    }


    public void PlayBoosterSound()
    {

        _boosterSound.Play();
    }
}
