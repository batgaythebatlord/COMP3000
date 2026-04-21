using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Runtime.Hosting;
using System.Threading;
using TMPro;
using System.Reflection;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dialogueSidebar : MonoBehaviour
{
    [SerializeField] private GameObject dialogueDisplay;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject characterSpeaking;
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject percentileDie;
    [SerializeField] private GameObject d10;

    [SerializeField] private dialogueChoiceButton[] choiceButtons;

    private bool diceActive;

    private void Awake()
    {
        dialogueDisplay.SetActive(false);
        ResetDialogue();
    }

    private void OnEnable()
    {
        GameEvents.current.DialogueEventsScr.onDialogueStarted += DialogueStarted;
        GameEvents.current.DialogueEventsScr.onDialogueFinished += DialogueFinished;
        GameEvents.current.DialogueEventsScr.onDisplayDialogue += DisplayDialogue;
        GameEvents.current.DialogueEventsScr.onRollDice += RollDice;
        GameEvents.current.DialogueEventsScr.onDisplayPortrait += DisplayPortrait;
    }

    private void OnDisable()
    {
        GameEvents.current.DialogueEventsScr.onDialogueStarted -= DialogueStarted;
        GameEvents.current.DialogueEventsScr.onDialogueFinished -= DialogueFinished;
        GameEvents.current.DialogueEventsScr.onDisplayDialogue -= DisplayDialogue;
        GameEvents.current.DialogueEventsScr.onRollDice -= RollDice;
        GameEvents.current.DialogueEventsScr.onDisplayPortrait -= DisplayPortrait;
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

    void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        dialogueText.text = dialogueLine;

        if (dialogueChoices.Count > choiceButtons.Length)
        {
            UnityEngine.Debug.LogError("More dialogue choices (" 
                + dialogueChoices.Count + ") came through than are supported (" 
                +  choiceButtons.Length + ")");
        }

        foreach(dialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        int choiceButtonIndex = dialogueChoices.Count - 1;
        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialogueChoice = dialogueChoices[inkChoiceIndex];
            dialogueChoiceButton choiceButton = choiceButtons[choiceButtonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialogueChoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);

            if(inkChoiceIndex == 0)
            {
                choiceButton.SelectButton();
                GameEvents.current.DialogueEventsScr.UpdateChoiceIndex(0);
            }

            choiceButtonIndex--;
        }

        //if (diceActive)
        //{
        //    percentileDie.gameObject.SetActive(false);      make this stick around for 1 line
        //}
    }

    void RollDice()
    {
        //write out all the logic for rolling and displaying dice here - might go into more than 1 method
        diceActive = true;
        percentileDie.gameObject.SetActive(true);
    }

    void DisplayPortrait(string portrait)
    {
        //?????????????
    }

    void ResetDialogue()
    {
        dialogueText.text = "";
    }

    //build something so that the speaking image resets and then changes to the relevant person while dialogue active
    //in this case the relevant person is family guy astacus
}
