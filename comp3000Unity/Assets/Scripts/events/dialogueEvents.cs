using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class dialogueEvents
{
    public event Action<string> onEnterDialogue;

    public void EnterDialogue(string knotName)
    {
        if (onEnterDialogue != null)
        {
            onEnterDialogue(knotName);
        }
    }

    public event Action onDialogueStarted;

    public void DialogueStarted() 
    {
        if (onDialogueStarted != null)
        {
            onDialogueStarted();
        }
    }

    public event Action onDialogueFinished;

    public void DialogueFinished()
    {
        if (onDialogueFinished != null)
        {
            onDialogueFinished();
        }
    }

    public event Action<string, List<Choice>> onDisplayDialogue;

    public void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        if (onDisplayDialogue != null)
        {
            onDisplayDialogue(dialogueLine, dialogueChoices);
        }
    }

    public event Action<int> onUpdateChoiceIndex;

    public void UpdateChoiceIndex(int choiceIndex)
    {
        if(onUpdateChoiceIndex != null)
        { 
            onUpdateChoiceIndex(choiceIndex);
        }
    }

    public event Action onRollDice;

    public void RollDice()
    {
        if(onRollDice != null)
        {
            onRollDice(); 
        }
    }

    public event Action<string> onDisplayPortrait;

    public void DisplayPortrait(string portrait)
    {
        if(onDisplayPortrait != null)
        {
            onDisplayPortrait(portrait);
        }
    }

    public event Action<string> onShowState;

    public void ShowState(string character)
    {
        if (onShowState != null)
        {
            onShowState(character);
        }
    }


}
