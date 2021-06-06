using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;

    public bool itemEnabled;


    public Item targetItem = null;

    public Interactions[] interactions;

    public bool playerCanTalkTo;

    public bool playerCanRead;

    public bool playerCanGiveTo = false;

    public bool InteractWith(GameManager gameManager ,string actionKeyword , string noun = "")
    {
        foreach (Interactions interaction in interactions)
        {
            if (interaction.action.keyWord == actionKeyword )
            {
                if (noun != null && noun.ToLower() != interaction.textToMatch.ToLower())
                    continue;
                    foreach (Item disableItem in interaction.itemsToDisable)
                        disableItem.itemEnabled = false;

                    foreach (Item enableItem in interaction.itemsToEnable)
                        enableItem.itemEnabled = true;

                    foreach (Connections disableconnection in interaction.connectionToDisable)
                        disableconnection.connectionEnabled = false;

                    foreach (Connections enableConnection in interaction.connectionToEnable)
                        enableConnection.connectionEnabled = true;

                if (interaction.teleportLocation != null)
                {
                    gameManager.player.Teleport(gameManager, interaction.teleportLocation);
                }

                    gameManager.currentText.text = interaction.response;
                    gameManager.DisplayLocation(true);

                    return true;

                
            }
        }
        return false;
    }

}
