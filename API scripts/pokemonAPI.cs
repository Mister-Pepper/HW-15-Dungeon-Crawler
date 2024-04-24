using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;  // web requests
using UnityEngine.UI;           // Required for UI like text

public class pokemonAPI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://pokeapi.co/api/v2/"));
    }

    public IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // request page
            yield return webRequest.SendWebRequest();

            if(webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                // show what comes up as text
                print(webRequest.downloadHandler.text);

                // according to class we could also do this in binary data form

                // byte[] results = webRequest.downloadHandler.data;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
