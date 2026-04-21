using UnityEngine;
using Ink.Runtime;
using System;
using System.Collections;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("rollDice", () => rollDice());
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("rollDice");
    }

    private void rollDice()
    {
        GameEvents.current.DialogueEventsScr.RollDice();
    }
}
