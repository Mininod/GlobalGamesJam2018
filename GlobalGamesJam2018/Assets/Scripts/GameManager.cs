using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            print("we timed out");
        }
        //levelTimerText.text=game
	}
}
