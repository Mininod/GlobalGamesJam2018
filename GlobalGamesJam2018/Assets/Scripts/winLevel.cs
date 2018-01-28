using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IsActivePlayer>())
        {
            if (!other.isTrigger && other.GetComponent<IsActivePlayer>().getIsActivePlayer() == true)
            {
                print("win");
                
                SceneManager.LoadScene(2);

            }
        }
    }
}
