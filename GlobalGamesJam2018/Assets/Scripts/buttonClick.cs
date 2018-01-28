using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadMain()
    {
        SceneManager.LoadScene(0);
    }

    public void loadCredit()
    {
        SceneManager.LoadScene(4);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
