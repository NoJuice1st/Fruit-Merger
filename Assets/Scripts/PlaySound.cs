using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip soundToPlay;

    public void PlayTheSound()
    {
        AudioSystem.Play(soundToPlay);
    }
}
