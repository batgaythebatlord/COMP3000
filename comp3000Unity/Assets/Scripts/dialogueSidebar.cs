using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
//using System.Runtime.Hosting;
using System.Threading;
using TMPro;
using UnityEngine;
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

    [SerializeField] private charaShauna ShaunaScr;
    [SerializeField] private charaRomello RomelloScr;

    private bool diceRoll;
    private bool diceActive;
    private bool displayingState = false;

    

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
        GameEvents.current.DialogueEventsScr.onShowState += ShowState;
    }

    private void OnDisable()
    {
        GameEvents.current.DialogueEventsScr.onDialogueStarted -= DialogueStarted;
        GameEvents.current.DialogueEventsScr.onDialogueFinished -= DialogueFinished;
        GameEvents.current.DialogueEventsScr.onDisplayDialogue -= DisplayDialogue;
        GameEvents.current.DialogueEventsScr.onRollDice -= RollDice;
        GameEvents.current.DialogueEventsScr.onDisplayPortrait -= DisplayPortrait;
        GameEvents.current.DialogueEventsScr.onShowState -= ShowState;
    }

    void DialogueStarted()
    {
        percentileDie.gameObject.SetActive(false);
        d10.gameObject.SetActive(false);
        dialogueDisplay.SetActive(true);
    }

    void DialogueFinished()
    {
        dialogueDisplay.SetActive(false);
        ResetDialogue();
    }

    void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        if(!displayingState)
        { 
            dialogueText.text = dialogueLine; 
        }
        displayingState = false;

        if (diceActive)
        {
            percentileDie.gameObject.SetActive(false);
            d10.gameObject.SetActive(false);
        }

        if(diceRoll)
        {
            diceActive = true;
            diceRoll = false;
            percentileDie.gameObject.SetActive(true);
            d10.gameObject.SetActive(true);
        }

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
    }

    void RollDice()
    {
        //write out all the logic for rolling and displaying dice here - might go into more than 1 method
        diceRoll = true;

        System.Random rnd = new System.Random();

        int percentileDieInt = rnd.Next(0, 10);
        int d10Int = rnd.Next(0, 10);

        UnityEngine.Debug.Log("Dice roll: " + percentileDieInt + d10Int);
    }

    void DisplayPortrait(string portrait)
    {
        //?????????????
    }

    void ShowState(string character)
    {
        displayingState = true;

        if (character == "Shauna")
        {
            dialogueText.text = "Shauna annoyance: " + ShaunaScr.returnState("annoyance") + "\nShauna trust: " + ShaunaScr.returnState("trust");
        }
        else if(character == "Romello")
        {
            dialogueText.text = "Romello annoyance: " + RomelloScr.returnState("annoyance") + "\nRomello trust: " + RomelloScr.returnState("trust");
        }
        else
        {
            dialogueText.text = "Character not recognised: " + character;
        }
    }

    void ResetDialogue()
    {
        dialogueText.text = "";
    }

    //build something so that the speaking image resets and then changes to the relevant person while dialogue active
    //in this case the relevant person is family guy astacus
}
