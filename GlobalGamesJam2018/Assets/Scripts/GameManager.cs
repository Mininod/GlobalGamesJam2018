using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public float levelTimer;
    private float currentLevelTimer;

    private Text levelTimerText;
 
	// Use this for initialization
	void Start ()
    {
        currentLevelTimer = levelTimer;
        levelTimerText = GameObject.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentLevelTimer -= Time.deltaTime;
        //print(currentLevelTimer);
        if(currentLevelTimer<0)
        {
            // game over? / lose a life
            
            SceneManager.LoadScene(3);
        }
        levelTimerText.text = (System.Math.Ceiling(currentLevelTimer)).ToString();
	}
}
