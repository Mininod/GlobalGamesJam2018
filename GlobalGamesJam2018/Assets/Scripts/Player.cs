using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    // transfer code 
    public float hp;
    public float soulTimer;
    public float soulTransmitDistance;
    private bool soulTimerActive;
    private GameObject enemyLastHit;
    // Use this for initialization
    void Start()
    {
        GetComponent<IsActivePlayer>().setActivePlayer(true);
        if (soulTimer > 0)
        {
            soulTimerActive = true; //DELETE ME ONCE YOU NO LONGER NEED ME :,(
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (soulTimerActive == true)
        {
            soulTimer -= Time.deltaTime;
            if (soulTimer < 0)
            {
                soulTimerActive = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<movement>().Movement(false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<movement>().Movement(true);
            }
            else
            {
                GetComponent<movement>().StopMovement();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<movement>().Jump();
            }

            //debug
            enemyLastHit = GameObject.Find("Warrior"); //Make a way to find the enemy last hit
            //debug

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (enemyLastHit.transform.position.x >= transform.position.x - soulTransmitDistance && enemyLastHit.transform.position.x <= transform.position.x + soulTransmitDistance)
                {
                    Debug.Log("Good to transmit bb");
                    enemyLastHit.AddComponent<Player>();
                    enemyLastHit.GetComponent<Player>().hp = enemyLastHit.GetComponent<AI>().GetHp();
                    GetComponent<AI>().enabled = true; //Sets This Gameobject to have AI
                    GetComponent<AI>().SetSoulTimer(soulTimer);
                    enemyLastHit.GetComponent<Player>().soulTimer = enemyLastHit.GetComponent<AI>().GetSoulTimer();
                    enemyLastHit.GetComponent<AI>().enabled = false; //Disables AI of target
                    GetComponent<IsActivePlayer>().setActivePlayer(false);
                    Destroy(GetComponent<Player>()); //Destory This Script 
                }
            }
        }
        else
        {
            print("rip boi");
        }
    }


    public void takeDamage(int damage)
    {
        hp -= damage;
    }

}
