 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Inhabitant
{
   
   private Room currentRoom;

   // add a constant player damage which will act a base outside of RPG of roll for attacks
   public int baseDMG = 0;

   // functions
   public Player(string name) : base(name)
   { 
   
   }

   public void resetStats()
   {
      this.hp = this.maxHP;
   }
   
}
