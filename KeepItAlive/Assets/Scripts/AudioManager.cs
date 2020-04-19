using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public AudioClip collisionAudio;
    public AudioClip goodStuffAudio;
    public AudioClip badStuffAudio;
    public AudioClip music;

    private AudioSource effectSource;
    private AudioSource musicSource;


    // Start is called before the first frame update
    void Start() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            AudioSource[] sources = GetComponents<AudioSource>();
            effectSource = sources[0];
            musicSource = sources[1];
        } else if (instance != this)
            Destroy(gameObject);
    }

    public void PlayMusic() {
        musicSource.clip = music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic() {
        musicSource.Stop();
    }

    public void PlayCollided() {
        effectSource.clip = collisionAudio;
        effectSource.Play();
    }

    public void PlayPickedGoodStuff() {
        effectSource.clip = goodStuffAudio;
        effectSource.Play();
    }

    public void PlayPickedBadStuff() {
        effectSource.clip = badStuffAudio;
        effectSource.Play();
    }
}
