using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float levelTimer;
    private float currentLevelTimer;


	// Use this for initialization
	void Start ()
    {
        currentLevelTimer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentLevelTimer += Time.deltaTime;
        print(currentLevelTimer);
        if(currentLevelTimer>levelTimer)
        {
            // game over? / lose a life
        }
	}
}
