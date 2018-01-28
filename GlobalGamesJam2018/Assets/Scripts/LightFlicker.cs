using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    private Light lanternLight;
    float time;
    float standardIntensity;
    bool isGoingUp;

	// Use this for initialization
	void Start () {
        isGoingUp = true;
        time = 0;
        lanternLight = transform.GetChild(0).GetComponent<Light>();
        standardIntensity = lanternLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        time += Time.deltaTime;
        if (time > 0.5)
        {
            float rand = Random.Range(9f, 10f);
            lanternLight.intensity = rand;
            time = Random.Range(0f,0.3f);
        }*/

        if (time > 1.5)
        {
            isGoingUp = false;
        }
        if(time < 0)
        {
            isGoingUp = true;
        }

        if (isGoingUp)
        {
            time += Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        lanternLight.intensity = (standardIntensity-2) + time * 1.5f;

        if (Input.GetKey(KeyCode.L))
        {
            standardIntensity = Random.Range(1f, 100f);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            standardIntensity = 8;
        }

       //time += Time.deltaTime;
       /* if(time > 0.1)
        {
            lanternLight.intensity = standardIntensity;
        }


        if(time > 3)
        {
            lanternLight.intensity = standardIntensity + 2;
            time = 0;
        }*/
	}
}
