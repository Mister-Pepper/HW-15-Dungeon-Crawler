using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Pellet addPellet(Pellet p, string direction)
    {
        if (direction.Equals"north")
        {
            this.northPellet = p;
        }
        else if (direction.Equals"south")
        {
            this.northPellet = p;
        }
        else if (direction.Equals"east")
        {
            this.northPellet = p;
        }
        else if (direction.Equals"west")
        {
            this.northPellet = p;
        }
        else
        {
            Debug.log("Not a valid pellet direction");
        }
    }

    public Pellet removePellet(string direction)
    {
        if (direction.Equals"north")
        {
            this.northPellet = null;
        }
        else if (direction.Equals"south")
        {
            this.northPellet = null;
        }
        else if (direction.Equals"east")
        {
            this.northPellet = null;
        }
        else if (direction.Equals"west")
        {
            this.northPellet = null;
        }
        else
        {
            Debug.log("Not a valid pellet direction to add");
        }
    }

     public bool hasPellet(string direction)
    {
        if (direction.Equals"north")
        {
            return this.northPellet != null;
        }
        else if (direction.Equals"south")
        {
            this.northPellet = null;
        }
        else if (direction.Equals"east")
        {
            this.northPellet = null;
        }
        else if (direction.Equals"west")
        {
            this.northPellet = null;
        }
        else
        {
            Debug.log("Not a valid pellet direction to remove");
        }
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
        }
    }

   
}
