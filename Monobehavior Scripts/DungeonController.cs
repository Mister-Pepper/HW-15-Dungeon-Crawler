using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 

3/13 Video 12 minutes in with error popping up for dungeon controller
about being out of array index. So far only error, but expecting one more as
video starts to speak of an issue coming up


*/



public class DungeonController: MonoBehaviour
{
   public GameObject northDoor, southDoor,eastDoor, westDoor;

    // Start is called before the first frame update
    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if(theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
        }
        if(theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
        }
        if(theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
        }
        if(theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}