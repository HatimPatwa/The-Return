using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Go")]
public class Go : Action
{
    public override void ResponseToInput(GameManager controller, string noun)
    {
        if (controller.player.ChangeLocation(controller,noun))
        {
            controller.DisplayLocation();
        }
        else
        {
            controller.currentText.text = "you can't go that way.";
        }
    }
}
