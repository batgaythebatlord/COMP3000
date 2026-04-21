using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel.Design.Serialization;

public class dialogueChoiceButton : MonoBehaviour, ISelectHandler
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text choiceText;

    private int choiceIndex = -1;

    public void SetChoiceText(string choiceTextString)
    {
        choiceText.text = choiceTextString;
    }

    public void SetChoiceIndex(int choiceIndex)
    {
        this.choiceIndex = choiceIndex;
    }

    public void SelectButton()
    {
        button.Select();
    }

    public void OnSelect(BaseEventData eventData)
    {
        GameEvents.current.DialogueEventsScr.UpdateChoiceIndex(choiceIndex);
    }
}