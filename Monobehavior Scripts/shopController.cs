using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopController : MonoBehaviour
{
    public GameObject boostItem;
    public itemCost boost;

    // Start is called before the first frame update
    void Start()
    {
        print("Would you like to buy an attack damage boost? (Y/N)");      // will be output to console
    }

    // Update is called once per frame
    void Update()
    {
        // we make it so if any point the user decides to buy the item, they just press a key and get charged and have their attack
        // damage boosted. Otherwise they will be able to press e to load up the dungeon and leave the shop

        // also need to make sure they player actually has enough pellets to buy the boost
        if(Input.GetKeyUp(KeyCode.Y) && MySingleton.currentPellets > boost.attackDamageBoostCost)
        {
            MySingleton.currentPellets--; // decrement current pellets here since cost is only 1;
            
            // now we need to update the players base damage
            MySingleton.thePlayer.baseDMG += 5; // this will give us a damage boost of 5 gained from every 1 boost bought
        }
    }
}
