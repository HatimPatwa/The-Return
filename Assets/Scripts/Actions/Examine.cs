using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void ResponseToInput(GameManager controller, string noun)
    {
        // check item in room
        if (checkItems(controller, controller.player.currentLocation.items, noun))
            return;

        // check item in inventory
        if (checkItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "You can't see a  " + noun;
    }

    private bool checkItems(GameManager gameManager , List<Item> items , string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                
                    if (item.InteractWith(gameManager, "examine"))
                        return true;
                
                gameManager.currentText.text = "There's nothing interesting about the " + noun;
                
                return true;
            }
        }
        return false;
    }
}
