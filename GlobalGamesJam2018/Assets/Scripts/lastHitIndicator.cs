using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastHitIndicator : MonoBehaviour {

    public GameObject lastHit;

	// Use this for initialization
	void Start () {
        lastHit = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (lastHit != null)
        {
            transform.position = new Vector2(lastHit.transform.position.x -0.5f, lastHit.transform.position.y +1.5f);
        }
	}
}
