using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant 
{
    protected string name;
    protected Room currentRoom;
    protected int hp, ac, maxHP; 
    
    //constructor

    public Inhabitant(string s)
    {
        this.name = name; 
        this.currentRoom = null;
        this.maxHP = this.hp;
        this.hp = Random.Range(10,16);
        this.ac = Random.Range(8,17);
    }

    public Room getCurrentRoom()
   {
    return this.currentRoom;
   }
   
   public void setCurrentRoom(Room r)
   {
     this.currentRoom = r;
   } 

   public int getHP()
   {
      return this.hp;
   }

   public int getAC()
   {
      return this.ac;
   }

   public void takeDamage(int pain)
   {
    this.hp = this.hp - pain; //reduction in hit points takes place here
   }

   public void addHP(int intHP)
   {
      if (intHP > 0)
      {
         this.hp += intHP;

            // protects against overhealing
         if (this.hp > this.maxHP)
         {
            this.hp = this.maxHP;
         }
      }
   }



}
