using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Action
{
    public override void ResponseToInput(GameManager controller, string noun)
    {
        if (SayToItem(controller, controller.player.currentLocation.items, noun))
            return;

        controller.currentText.text = "responds nothing";
    }

    private bool SayToItem(GameManager gameManager , List<Item> items , string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (gameManager.player.CanTalkToItem(gameManager, item))
                {
                    if (item.InteractWith(gameManager,"say",noun))
                    {
                        return true;
                    }
                }
            }
            
        }
        return false;
    }
}
