using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public dialogueEvents DialogueEventsScr;
    public relationshipEvents RelationshipEventsScr;

    private void Awake()
    {
        current = this;

        DialogueEventsScr = new dialogueEvents();
        RelationshipEventsScr = new relationshipEvents();
    }
}
