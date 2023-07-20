using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class BeatCode : MonoBehaviour
{
    public AudioClip beatAudio;
    private AudioSource src;
    private Volume post;
    private void Awake()
    {
        post = GameObject.Find("Global Volume").GetComponent<Volume>();
    }
    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void PlayBeat()
    {
        src.PlayOneShot(beatAudio);
    }
}
