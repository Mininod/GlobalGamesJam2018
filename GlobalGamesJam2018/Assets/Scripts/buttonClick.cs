using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour {

    public GameObject audioThing;

    // Use this for initialization
    void Start() {
        audioThing = GameObject.Find("AudioController");
    }

    // Update is called once per frame
    void Update() {

    }

    public void LoadGame()
    {
        audioThing.GetComponent<AudioControllerScript>().PlayAudioClip(3);
        SceneManager.LoadScene(1);
    }

    public void loadMain()
    {
        audioThing.GetComponent<AudioControllerScript>().PlayAudioClip(3);
        SceneManager.LoadScene(0);
    }

    public void loadCredit()
    {
        audioThing.GetComponent<AudioControllerScript>().PlayAudioClip(3);
        SceneManager.LoadScene(4);
    }

    public void closeGame()
    {
        audioThing.GetComponent<AudioControllerScript>().PlayAudioClip(3);
        Application.Quit();
    }
}
