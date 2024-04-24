using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class shopController : MonoBehaviour
{
    // need the TMPs of the objects on the screen to display cost and available pellets
    public TextMeshPro playerTMP, itemTMP;
    public GameObject boostItem;
    public itemCost boost;

    // Start is called before the first frame update
    void Start()
    {
        this.updatePlayerTMP();
        this.itemTMP.text = "" + ItemsSingleton.cherryItemCost; 

        // read plain text file
        //this.readItemsData();

        // read JSON file with serialization
        string jsonString = MySingleton.readJsonString();     

    

        //parse JSON file
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);

        //output the data to the console
        foreach(var item in root.items)
        {
            print($"Name: {item.name}, Stat Impacted: {item.stat_impacted}, Modifier: {item.modifier}");
        }

    }

    private void updatePlayerTMP()
    {
        this.playerTMP.text = "" + MySingleton.currentPellets;
    }

    private void readItemsData()
    {
        string filePath  = "Assets/files/Items_data.rtf"; // copied path over from the file
        string answer = "";

        // first verify if the file even exists
        if(File.Exists(filePath))
        {
            try
            {
    
                // open the file to read from
                using(StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    string[] itemParts = new string[3];
                    int pos = 0;

                    // read display lines from file until the file is empty
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(",");
                        for(int count = 0; count < parts.Length; count++)
                        {
                            print(parts[count]);
                            itemParts[pos%3] = parts[count];
                            pos++;
                        }
                        print("Manually parsed with the Item Object");
                        Item theItem = new Item(itemParts[0], itemParts[1], int.Parse(itemParts[2]));
                        theItem.display();
                    }
                }
            }

            catch(Exception ex)
            {
                // display any errors that occurred while doing this with the file
                print("An error ocurred while reading the file... womp womp");

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        // we make it so if any point the user decides to buy the item, they just press a key and get charged and have their attack
        // damage boosted. Otherwise they will be able to press e to load up the dungeon and leave the shop

        // also need to make sure they player actually has enough pellets to buy the boost
        /*if(Input.GetKeyUp(KeyCode.Y) && MySingleton.currentPellets > boost.attackDamageBoostCost)
        {
            MySingleton.currentPellets--; // decrement current pellets here since cost is only 1;
            
            // now we need to update the players base damage
            MySingleton.thePlayer.baseDMG += 5; // this will give us a damage boost of 5 gained from every 1 boost bought
        }

        */

        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            // now we can deduct the cost of the item from the pellets of the player IF they can afford the item
            if(MySingleton.currentPellets > ItemsSingleton.cherryItemCost)
            {
                MySingleton.currentPellets -= ItemsSingleton.cherryItemCost;

                // mess with the players HP now that they bought the boost
                MySingleton.thePlayer.addHP(5);
                this.updatePlayerTMP();
            }

        }
    }
}