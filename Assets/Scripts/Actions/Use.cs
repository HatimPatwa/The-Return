using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action

{
    public override void ResponseToInput(GameManager controller, string noun)
    {
        // use item in room
        if (UseItems(controller, controller.player.currentLocation.items, noun))
            return;

        // use item in inventory
        if (UseItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no "+noun;
    }

    private bool UseItems(GameManager gameManager, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (gameManager.player.CanUseItem(gameManager,item))
                {
                    if (item.InteractWith(gameManager, "use"))
                        return true;
                }
               
                gameManager.currentText.text = "The " + noun + " does nothing. ";
                return true;
            }
        }
        return false;
    }
}

