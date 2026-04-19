using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Runtime.Hosting;
using System.Threading;
using TMPro;
using System.Reflection;

public class dialogueSidebar : MonoBehaviour
{
    [SerializeField] private GameObject dialogueDisplay;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject characterSpeaking;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject percentileDie;
    [SerializeField] private GameObject d10;


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

    //build something so that the speaking image resets and then changes to the relevant person while dialogue active
    //in this case the relevant person is family guy astacus
}
