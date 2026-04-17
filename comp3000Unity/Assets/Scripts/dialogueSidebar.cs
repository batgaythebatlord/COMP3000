using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Runtime.Hosting;
using System.Threading;
using TMPro;

public class dialogueSidebar : MonoBehaviour
{
    [SerializeField] private GameObject dialogueDisplay;
    [SerializeField] private TMP_Text dialogueText;

    private void Awake()
    {
        dialogueDisplay.SetActive(false);
        ResetDialogue();
    }

    void DialogueStarted()
    {
        dialogueDisplay.SetActive(true);
    }

    void DialogueFinished()
    {
        dialogueDisplay.SetActive(false);
        ResetDialogue();
    }

    void DisplayDialogue(string dialogueLine)
    {
        dialogueText.text = dialogueLine;
    }

    void ResetDialogue()
    {
        dialogueText.text = "";
    }
}
