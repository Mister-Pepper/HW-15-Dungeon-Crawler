using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theCollectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // read JSON file with serialization
        string jsonString = MySingleton.readJsonString();

        // parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
