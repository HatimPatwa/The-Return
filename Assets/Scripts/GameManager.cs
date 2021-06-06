using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;

    public InputField entryText;

    public Text logText;

    public Text currentText;

    public Action[] actions;

    [TextArea] public string introText;
    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;

        DisplayLocation();
        entryText.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = "\n" +  player.currentLocation.description + "\n";

        description += player.currentLocation.GetConnectionText();

        description += player.currentLocation.GetItemNames();
        if (additive)
            currentText.text = currentText.text + "\n" + description;
        else
            currentText.text = description;
    }

    public void TextEntered()
    {
        Debug.Log("text entered");
        LogCurrentText();
        ProcessInput(entryText.text);
        entryText.text = "";
        entryText.ActivateInputField();
    }

    public void LogCurrentText()
    {
        logText.text = "\n\n"; 
        logText.text += currentText.text;

        logText.text += "\n\n";
        logText.text += "<color=#ffffff >" + entryText.text + "</color>";

    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] seperatedWords = input.Split(delimiter);

        foreach (Action action in actions)
        {
            if (action.keyWord.ToLower() == seperatedWords[0])
            {
                if (seperatedWords.Length > 1)
                {
                    action.ResponseToInput(this, seperatedWords[1]);
                }
                else
                {
                    action.ResponseToInput(this, "");
                }
                return;
            }
            
        }

        currentText.text = "Nothing Happend ,(Having trouble ? type Help) ";
    }
}
