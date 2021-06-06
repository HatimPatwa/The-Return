using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void ResponseToInput(GameManager controller, string verb)
    {
        controller.currentText.text = "Type a verb followd by a noun e.g \" go north \"";
        controller.currentText.text += "\nAllowed Verbs \nGo, Examine, Get, Use, Inventory, Say, TalkTo, Help, Give,Read";
    }
}
