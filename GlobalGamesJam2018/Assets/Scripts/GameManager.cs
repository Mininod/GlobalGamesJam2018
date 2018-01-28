using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    private float currentLevelTimer;

    private Text levelTimerText;
 
	// Use this for initialization
	void Start ()
    {
        currentLevelTimer = 0;
        levelTimerText = GameObject.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentLevelTimer += Time.deltaTime;
        //print(currentLevelTimer);
        levelTimerText.text = (currentLevelTimer).ToString("00.00");
	}
}
