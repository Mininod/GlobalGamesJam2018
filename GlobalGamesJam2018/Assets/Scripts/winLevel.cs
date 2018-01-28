using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winLevel : MonoBehaviour {

    public Text timer;
    private Text savedTimer;
    private bool gameEnded;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        gameEnded = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (gameEnded)
        {
            GameObject VicText = GameObject.Find("ScoreText");
            if(VicText != null)
            {
                VicText.GetComponent<Text>().text = "You Completed the level in: " + savedTimer.text.ToString();
                gameEnded = false;
                Destroy(gameObject);
            }
        }
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IsActivePlayer>())
        {
            if (!other.isTrigger && other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
            {
                savedTimer = timer;
                print("win");
                
                SceneManager.LoadScene(2);
                gameEnded = true;
            }
        }
    }
}
