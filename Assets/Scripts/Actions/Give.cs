using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Give")]
public class Give : Action
{
    public override void ResponseToInput(GameManager controller, string noun)
    {
        if (controller.player.HasItemByName(noun))
        {
            if (GiveToItem(controller, controller.player.currentLocation.items, noun))
                return;

            controller.currentText.text = "Nothing takes the " + noun;
            return;
        }

        controller.currentText.text = "You don't have " + noun + " to give" ;

    }

    private bool GiveToItem(GameManager gameManager, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (gameManager.player.CanGiveToItem(gameManager, item))
                {
                    if (item.InteractWith(gameManager, "give", noun))
                    {
                        return true;
                    }
                }
            }

        }
        return false;
    }
}
