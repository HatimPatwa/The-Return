using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactions
{
    public Action action;

    [TextArea]
    public string response;

    public string textToMatch;  

    public List<Item> itemsToDisable = new List<Item>();
    public List<Item> itemsToEnable = new List<Item>();

    public List<Connections> connectionToDisable = new List<Connections>();
    public List<Connections> connectionToEnable = new List<Connections>();

    public Location teleportLocation = null ;






}
