using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class theCollectionManager : MonoBehaviour
{
    public Material placeHolderMaterial, potionMaterial;
    public GameObject itemPrefab;
    private Vector3 startPosition;
    private int itemSpawned = 0;
    private int currentLeftPos = 0;
    private List<GameObject> theItemsGO = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {   

        // start off with serialization so we can use the bits of information in our text mesh pros
        //read json file with serialization
        string jsonString = MySingleton.readJsonString();

        // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);

        for(int i = 0; i < 10; i++)
        {
            this.startPosition = new Vector3(-3.7f + (this.itemSpawned * 2.51f), 0f, 0f);
            GameObject newObect = Instantiate(this.itemPrefab, this.startPosition, Quaternion.identity);
            TextMeshPro tmp = newObect.transform.GetChild(0).GetComponent<TextMeshPro>();
            tmp.SetText(jsonString);
            //tmp.SetText("Item " + i + "\nCost: 5");
            newObect.transform.SetParent(this.gameObject.transform);
            newObect.transform.localPosition = this.startPosition;
            newObect.transform.localRotation = Quaternion.identity;
            if(this.itemSpawned >= 4)
            {
                newObect.SetActive(false);
            }
            this.itemSpawned++;
            this.theItemsGO.Add(newObect);
        }
        
       

        //NEWWWWWW FOR HW ASSIGNMENT ***********************

        /* need to have a for loop to go through the each item and part of JSON file and link it to the object TMP
        for(int count = 0; count < 10; count++)
        {
            textObject 
            this.theItemsGO[count].GetChild(0).GetComponent<TextMeshPro>()
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) && this.currentLeftPos <= this.theItemsGO.Count - 5)
        {
            //move everything left one item
            GameObject tempLeft = null, tempRight = null;

            //goes through our items and moves them appropriately and makes them visible/invisible as needed
            for(int i = 0; i < this.theItemsGO.Count; i++)
            {
                this.theItemsGO[i].transform.Translate(Vector3.left * 5.0f);
                if(i == this.currentLeftPos)
                {
                    tempLeft = this.theItemsGO[i];
                }

                if(i == this.currentLeftPos + 4)
                {
                    tempRight = this.theItemsGO[i];
                }
            }
            tempLeft.SetActive(false);
            tempRight.SetActive(true);
            this.currentLeftPos++;

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && this.currentLeftPos >= 1)
        {
            //move everything left one item
            GameObject tempLeft = null, tempRight = null;

            for (int i = 0; i < this.theItemsGO.Count; i++)
            {
                this.theItemsGO[i].transform.Translate(Vector3.right * 5.0f);
                if (i == this.currentLeftPos - 1)
                {
                    tempLeft = this.theItemsGO[i];
                }

                if (i == this.currentLeftPos + 3)
                {
                    tempRight = this.theItemsGO[i];
                }
            }
            tempLeft.SetActive(true);
            tempRight.SetActive(false);
            this.currentLeftPos--;

        }
    }
}

/*{

    public Material placeHolderMaterial, potionMaterial;
    public GameObject itemPrefab;
    private Vector3 startPosition;      
    private int itemSpawned = 0;
    private int currentLeftPos = 0;
    private List<GameObject> theItemsGO  = new List<GameObject>();

    //Start is called before the first frame update
    void Start()
    {

        for(int count = 0; count < 10; count++)
        {
            this.startPosition = new Vector3(-3.7f + (this.itemSpawned* 2.51f),0f,0f);
            GameObject newObject = Instantiate(this.itemPrefab, this.startPosition, Quaternion.identity);
            TextMeshPro tmp = newObject.transform.GetChild(0).GetComponent<TextMeshPro>();
            tmp.SetText("Item " + count + "\nCost: 5");
            newObject.transform.SetParent(this.gameObject.transform);
            newObject.transform.localPosition = this.startPosition;
            newObject.transform.localRotation = Quaternion.identity;
            if(this.itemSpawned >= 4)
            {
                newObject.SetActive(false);
            }

            this.itemSpawned++;
            this.theItemsGO.Add(newObject);
        }
        // read JSON file with serialization
        string jsonString = MySingleton.readJsonString();

        // parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) && this.currentLeftPos <= this.theItemsGO.Count - 5)
        {
            print("left arrow branch");

            // move everything to the left one position

            GameObject tempLeft = null, tempRight = null;

            // this loop goes through our items and moves them appropriately and make hte
            for(int count = 0; count < this.theItemsGO.Count; count++)
            {
                this.theItemsGO[count].transform.Translate(Vector3.left * 17.0f);
                if(count == this.currentLeftPos)
                {
                    tempLeft = this.theItemsGO[count];
                }
                if(count == this.currentLeftPos + 4)
                {
                    tempRight = this.theItemsGO[count];
                }
            }

            tempLeft.SetActive(false);
            tempRight.SetActive(true);
            this.currentLeftPos++;
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow) && this.currentLeftPos >= 1)
        {
            print("Right arrow branch");
            //move everything to the left one item
            GameObject tempLeft = null, tempRight = null;

            
            for(int count = 0; count < this.theItemsGO.Count; count++)
            {
                this.theItemsGO[count].transform.Translate(Vector3.right * 17.0f);

                if(count == this.currentLeftPos - 1)
                {
                    tempLeft = this.theItemsGO[count];
                }
                if(count == this.currentLeftPos + 3)
                {
                    tempRight = this.theItemsGO[count];
                }
            }

            tempLeft.SetActive(true);
            tempRight.SetActive(false);
            this.currentLeftPos--;
        }
    }
}

*/
