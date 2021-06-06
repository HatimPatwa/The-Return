using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void ResponseToInput(GameManager controller, string noun)
    {

        controller.currentText.text = "You have these items in your Inventory" + "\n";

        foreach (Item item in controller.player.inventory)
        { 
            
            controller.currentText.text += item.itemName + "\n";

        }
    }
}
