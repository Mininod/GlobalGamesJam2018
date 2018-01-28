using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

 //   private GameObject player;
 //   // Use this for initialization
 //   void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
 //       transform.position = new Vector3(player.transform.position.x, player.transform.position.y+3, -10);
 //   }

 //   public void setNewPlayer(GameObject newPlayer)
 //   {
 //       player = newPlayer;
 //   }



    private GameObject player;
    private GameObject oldPos;


    //Use this for initialization

   void Start()
    {
        //oldPos.transform.position = new Vector3(0,0,0);
        //oldPos.transform.position = new Vector3(transform.position.x, transform.position.y + 3, -10);
       setOldPos(gameObject);
    }
    public void setNewPlayer(GameObject newPlayer)
    {
        //player = newPlayer;

        player = newPlayer;

    }
    public void setOldPos(GameObject Pos)
    {
        oldPos = Pos;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (Vector2.Distance(transform.position,player.transform.position) > 3.5f)
        {
            Debug.Log("lerp");
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 3, -10), 0.06f);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3, -10);
        }


    }
}
