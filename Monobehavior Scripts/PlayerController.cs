using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using TMPro;
using UnityEngine.SceneManagement;
/*
*/

public class PlayerController : MonoBehaviour
{
    public TextMeshPro pellet_TMP;
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject middleOfRoom;

    public Scene currentScene;

    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;
    public float speed = 2.0f;


    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);
        
    }

    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //need a game object of type scene to compare down the road
        currentScene = SceneManager.GetActiveScene();
        
        this.pellet_TMP.text = "" + MySingleton.currentPellets; // for string 
        // turn off exits when we initially load a scene
        turnOffExits();

        // also turn off the middle of the room as soon as the scene loads, even though it already should be
        this.middleOfRoom.SetActive(false);

        if (!MySingleton.currentDirection.Equals("?"))
        {
            this.amMoving = true;
            this.middleOfRoom.SetActive(true);
            this.amAtMiddleOfRoom = false;

            if(MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
            }
            else if(MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
            }
            else if(MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
            }
            else if(MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
            }

            //StartCoroutine(turnOnMiddle());
        }
        else 
        {
            // we will keep positioning the player at the middle so we will need to 
            // keep the middle collider off for this run of the scene

            this.amMoving = false;
            this.amAtMiddleOfRoom = false;
            this.middleOfRoom.SetActive(false);
            this.gameObject.transform.position = this.middleOfRoom.transform.position;
        }
        

        print(MySingleton.currentDirection);
    }

   /* IEnumerator turnOnMiddle()
    {
        yield return new WaitForSeconds(1);
        this.middleOfRoom.SetActive(true);
    }
    */

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("door"))
        {
            MySingleton.thePlayer.getCurrentRoom().removePlayer(MySingleton.currentDirection);

            EditorSceneManager.LoadScene("Scene2");
        }
        else if(other.CompareTag("power-pellet"))
        {
            // this makes the pellet disappear in game
            other.gameObject.SetActive(false);
            // this makes the pellet dissappear programatically
            Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();

            theCurrentRoom.removePellet(other.GetComponent<pelletController>().direction);

            // this is where we will launch the scene, want the pellet code in the prefight scene to remain stable while we transition
            EditorSceneManager.LoadScene("FightScene");

        }

        /*if(MySingleton.firstTimeFirstRoom)
        {
            theCurrentRoom.removePellet(MySingleton.currentDirection);
            MySingleton.firstTimeFirstRoom = false;
        }
        else
        {
            theCurrentRoom.removePellet(MySingleton.flipDirection(MySingleton.currentDirection));
        }

        */

        else if (other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            // when we hit the middle collider, we turn it off so we dont run into it again
            this. middleOfRoom.SetActive(false);
            this.turnOnExits();

            this.amMoving = false;
            this.amAtMiddleOfRoom = true;
            MySingleton.currentDirection = "middle";
            print("middle");
        }

        print("crash");
    }

    // Update is called once per frame
    void Update()
    {
        // set the direction of the object based on the key they press
        if(Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("north"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }
        if(Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("south"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south"; 
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("west"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position); 
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("east"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);
        }

        // after we have determined the direction and updated singleton, we need to actually get the character to move that way
        if(MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,this.northExit.transform.position, this.speed*Time.deltaTime);
        }

        if(MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,this.southExit.transform.position, this.speed* Time.deltaTime);
        }

        if(MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,this.westExit.transform.position, this.speed* Time.deltaTime);
        }

        if(MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,this.eastExit.transform.position, this.speed* Time.deltaTime);
        }

    /*


    HW #22 Edits
    * Check if the current scene is the the fight scene
    * IF the scene is not a fight scene, implement IF status in update to see if user inputs escape key
    * IF the user inputs an escape key, that means that the shop keeper scene is loaded


    */

    // scene check
    if(currentScene.name != "FightScene" && Input.GetKeyUp(KeyCode.Escape)) // the player has pressed escape and the scene isnt fight
    {
        SceneManager.LoadScene("ShopKeeper");
    }

    }
    
   

}