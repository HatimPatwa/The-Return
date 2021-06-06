using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public string keyWord;

    public abstract void ResponseToInput(GameManager controller, string noun);

}
