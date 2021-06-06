using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void ResponseToInput(GameManager controller, string noun)
    {
        // use item in room
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
            return;

        // use item in inventory
        if (ReadItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is nothing to read ";
    }

    private bool ReadItems(GameManager gameManager, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (gameManager.player.CanReadItem(gameManager, item))
                {
                    if (item.InteractWith(gameManager, "read"))
                        return true;
                }

                gameManager.currentText.text = "The " + noun + " does nothing. ";
                return true;
            }
        }
        return false;
    }
}
