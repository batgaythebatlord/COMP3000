using UnityEngine;
using System;

public class dialogueEvents : MonoBehaviour
{
    public event Action<string> onEnterDialogue;

    public void EnterDialogue(string testKnot)
    {
        if (onEnterDialogue != null)
        {
            onEnterDialogue(testKnot);
        }
    }
}
