using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPellet : Pellet
{
  public ArmorPellet(): base(1)
  {
    // so we already have an instance of a pellet here, we are just differentiating between normal pellet and armor pellet below
        base.name = base.name + " : Armor Pellet";
  }
}
