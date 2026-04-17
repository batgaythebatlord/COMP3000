using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public dialogueEvents DialogueEventsScr;

    private void Awake()
    {
        current = this;

        DialogueEventsScr = new dialogueEvents();
    }
}
