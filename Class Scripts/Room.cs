using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// NOT SEtTING THE RIGHT PELLETS GOT THROUFH REST BUT PELLETS ARE NOT LOADINNG


public class Room 
{
    private string name;
    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private Player currentPlayer;

    private Pellet northPellet = null;
    private Pellet southPellet = null;
    private Pellet eastPellet = null;
    private Pellet westPellet = null;

    public Room(string name)
    {
        this.name  = name;

    }

    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this);    // updates player to their new current room
    }

    public void addPellet(Pellet p, string direction)
    {
        if (direction.Equals("north"))
        {
            this.northPellet = p;
        }
        else if(direction.Equals("south"))
        {
            this.southPellet = p;
        }
        else if (direction.Equals("east"))
        {
            this.eastPellet = p;
        }
        else if (direction.Equals("west"))
        {
            this.westPellet = p;
        }
        else
        {
            Debug.Log("Not a valid pellet direction");
        }
    }

    public void removePellet(string direction)
    {
        if (direction.Equals("north"))
        {
            this.northPellet = null;
        }
        else if (direction.Equals("south"))
        {
            this.southPellet = null;
        }
        else if (direction.Equals("east"))
        {
            this.eastPellet = null;
        }
        else if (direction.Equals("west"))
        {
            this.westPellet = null;
        }
        else
        {
            Debug.Log("Not a valid pellet direction to add");
        }
    }

     public bool hasPellet(string direction)
    {
        if (direction.Equals("north"))
        {
            return this.northPellet != null;
        }
        else if (direction.Equals("south"))
        {
          return this.southPellet != null;
        }
        else if (direction.Equals("east"))
        {
            return this.eastPellet != null;
        }
        else if (direction.Equals("west"))
        {
            return this.westPellet != null;
        }
        else 
        {
            Debug.Log("Not a valid pellet direction to remove");
            return false;
        }

        return false;

    }

    // remove the current player from the room
    public void removePlayer(string direction)
    {
        Exit theExit = this.getExitGivenDirection(direction);
        Room destinationRoom = theExit.getDestinationRoom();
        destinationRoom.addPlayer(this.currentPlayer);
        this.currentPlayer = null;
    }

    private Exit getExitGivenDirection(string direction)
    {
        for(int count = 0; count < this.howManyExits; count++)
        {
            if(this.theExits[count].getDirection().Equals(direction))
            {
                return this.theExits[count];    //returns the exit in the given direction
            }
        }

        return null; // this branch will only be executed if the we never found an exit
    }

    public bool hasExit(string direction)
    {
        for(int count = 0; count < this.howManyExits; count++)
        {
            if(this.theExits[count].getDirection().Equals(direction))
            {
                return true;
            }
        }

        return false;
    }

    public void addExit(string direction, Room destinationRoom)
    {
        if(this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[this.howManyExits] = e;
            this.howManyExits++;

            if(direction.Equals("north"))
            {
                this.northPellet = new ArmorPellet();
            }
            if(direction.Equals("south"))
            {
                this.southPellet = new ArmorPellet();
            }
            if(direction.Equals("east"))
            {
                this.eastPellet = new ArmorPellet();
            }
            if(direction.Equals("west"))
            {
                this.westPellet = new ArmorPellet();
            }
        }
    }

   
}
