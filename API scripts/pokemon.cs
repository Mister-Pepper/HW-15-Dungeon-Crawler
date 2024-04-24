using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class pokemon 
{
   public string name;
   public string url;

   // constructor 
   public pokemon(string name, string url)
   {
        this.name = name;
        this.url = url;
   }

   public void display()
   {
        Debug.Log("Name: {this.name},URL: {this.url}");
   }
}

[System.Serializable]
public class CollectionOfPokemon
{
    public int count;
    public string next;
    public string previous;
    public pokemon[] results;
}
