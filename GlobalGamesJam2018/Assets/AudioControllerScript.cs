using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerScript : MonoBehaviour {

    public AudioClip[] audioClipFiles;
    private AudioSource audioSource;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("AudioController").Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(int clipElement)
    {
        audioSource.clip = audioClipFiles[clipElement];
        audioSource.Play();
    }
}
