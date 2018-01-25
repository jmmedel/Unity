using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance = null;
    public AudioClip alienbuzz1;
    public AudioClip alienbuzz2;
    public AudioClip aliendies;
    public AudioClip bulletfire;
    public AudioClip shipexplosion;
    public AudioClip Background;
    private AudioSource soundeffectaudio;

	// Use this for initialization
	void Start () {
		if (Instance == null)
        {
            Instance = this;
        }
        else if( Instance != this)
        {
            Destroy(gameObject);
        }
        AudioSource thesource = GetComponent<AudioSource>();
        soundeffectaudio = thesource;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Playoneshot(AudioClip clip)
    {
        soundeffectaudio.PlayOneShot(clip);
    }
}
