using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastHitIndicator : MonoBehaviour {

    public GameObject lastHit;
    public Vector2 adjustment;

	// Use this for initialization
	void Start () {
        lastHit = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (lastHit != null)
        {
            transform.position = new Vector2(lastHit.transform.position.x + adjustment.x, lastHit.transform.position.y + adjustment.y);
        }
	}
}
