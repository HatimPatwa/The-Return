using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;

    public List<Item> inventory = new List<Item>();

    public bool HasItemByName(String noun)
    {
        foreach (Item item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeLocation(GameManager controller , string connectionNoun)
    {
        Connections connections = currentLocation.GetConnection(connectionNoun);
        if (connections != null)
        {
            if (connections.connectionEnabled)
            {
                currentLocation = connections.location;
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameManager gameManager , Location destination)
    {
        currentLocation = destination;  
    }

    internal bool CanGiveToItem(GameManager gameManager, Item item)
    {
        return item.playerCanGiveTo;
    }

    internal bool CanReadItem(GameManager gameManager, Item item)
    {
        return item.playerCanRead;
    }

    internal bool CanTalkToItem(GameManager gameManager, Item item)
    {
        return item.playerCanTalkTo;
    }

    internal bool CanUseItem(GameManager gameManager, Item item)
    {
        if (item.targetItem == null)
            return true;

        if (HasItem(item.targetItem))
            return true;

        if (currentLocation.HasItem(item.targetItem))
            return true;

        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in inventory)
        {
            if (item == itemToCheck && item.itemEnabled)
            {
                return true;
            }
            
        }
        return false;
    }
}
