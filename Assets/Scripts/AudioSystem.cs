using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    static AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public static void Play(AudioClip clip, float pitch = 1f, float speed = 1f)
    {
        source.pitch = pitch;
        
        source.PlayOneShot(clip);
    }
}
