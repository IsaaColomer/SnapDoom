using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class BeatCode : MonoBehaviour
{
    public AudioClip beatAudio;
    private Image image;
    private AudioSource src;
    private Volume post;
    public bool isOnBeat;
    private void Awake()
    {
        post = GameObject.Find("Global Volume").GetComponent<Volume>();
        image = GameObject.Find("BeatDebug").GetComponent<Image>();
    }
    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void PlayBeat()
    {
        src.PlayOneShot(beatAudio);
        isOnBeat = true;
        image.color = Color.green;
    }
    public void SetOnBeatToFalse()
    {
        image.color = Color.red;
        isOnBeat = false;
    }
}
