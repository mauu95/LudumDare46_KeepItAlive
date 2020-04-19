using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public AudioClip collisionAudio;
    public AudioClip goodStuffAudio;
    public AudioClip badStuffAudio;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start() {
        if (!instance) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        } else if (instance != this)
            Destroy(gameObject);
    }

    public void PlayCollided() {
        audioSource.clip = collisionAudio;
        audioSource.Play();
    }

    public void PlayPickedGoodStuff() {
        audioSource.clip = goodStuffAudio;
        audioSource.Play();
    }

    public void PlayPickedBadStuff() {
        audioSource.clip = badStuffAudio;
        audioSource.Play();
    }
}
