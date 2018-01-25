using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour {

    public static soundmanager Instance = null;
    public AudioClip goalbloop;
    public AudioClip lossbuzz;
    public AudioClip hitpaddlebloop;
    public AudioClip winsound;
    public AudioClip wallbloop;

    private AudioSource soundeffecaudio;

    // Use this for initialization
    void Start () {
        if (Instance == null)
        {
            Instance = this;

        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource[] sources = GetComponents<AudioSource>();
        foreach(AudioSource source in sources)
        {
            if (source.clip == null)
            {
                soundeffecaudio = source;
            }
        }

	}


    public void playoneshot(AudioClip clip)
    {
        soundeffecaudio.PlayOneShot(clip);

    }

}
