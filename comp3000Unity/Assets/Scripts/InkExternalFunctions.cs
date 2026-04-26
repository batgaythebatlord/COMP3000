using UnityEngine;
using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("rollDice", () => rollDice());
        story.BindExternalFunction("showState", (string character) => showState(character));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("rollDice");
        story.UnbindExternalFunction("showState");
    }

    private void rollDice()
    {
        GameEvents.current.DialogueEventsScr.RollDice();
    }

    private void showState(string character)
    {
        GameEvents.current.DialogueEventsScr.ShowState(character);
    }
}
