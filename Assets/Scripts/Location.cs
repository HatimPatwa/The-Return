using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{

    public string locationName;

    [TextArea] public string description;

    public Connections[] connections;
    
    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    public string GetItemNames()
    {
        if (items.Count == 0) return "";

        string result = "You see : ";

        bool first = true;

        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (!first) result += " and ";
                result += item.description;
                first = false;
            }
            
        }
        result += "\n";

        return result;
    }


    public string GetConnectionText()
    {
        string result = "";

        foreach (Connections connection in connections)
        {
            if (connection.connectionEnabled)
            {
                result += connection.description + "\n";
            }

        }
        return result;

    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck && item.itemEnabled)
                return true;

        }
        return false;
    }

    public Connections GetConnection(string connectionNoun)
    {
        foreach (Connections connection in connections)
        {
            if (connection.connectionName.ToLower() == connectionNoun.ToLower())
            {
                return connection;
            }
        }

        return null;
    }
}
