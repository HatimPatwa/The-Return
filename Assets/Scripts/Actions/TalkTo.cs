using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TalkTo")]
public class TalkTo : Action
{
    public override void ResponseToInput(GameManager controller, string noun)
    {
        if (TalkToItem(controller, controller.player.currentLocation.items, noun))
            return;

        controller.currentText.text = "There is no " + noun + " here!";
    }

    private bool TalkToItem(GameManager gameManager , List<Item> items , string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun && item.itemEnabled)
            {
                if (gameManager.player.CanTalkToItem(gameManager, item))
                {
                    if (item.InteractWith(gameManager, "talkto"))
                        return true;
                }

                gameManager.currentText.text = "The " + noun + " doesn't respond. ";
                return true;
            }
        }
        return false;
    }
}
