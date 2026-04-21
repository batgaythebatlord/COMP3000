using UnityEngine;
using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;

public class dialogueManager : MonoBehaviour
{
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private GameObject DialogueCanvas;

    private Story story;

    private int currentChoiceIndex = -1;

    public bool dialoguePlaying = false;

    private InkExternalFunctions inkExternalFunctions;


    private const string PORTRAIT_TAG = "portrait";
    private const string ANNOYANCE_TAG = "annoyance";
    private const string TRUST_TAG = "trust";


    private void Awake()
    {
        story = new Story(inkJson.text);
        inkExternalFunctions = new InkExternalFunctions();
        inkExternalFunctions.Bind(story);
    }

    private void OnDestroy()
    {
        inkExternalFunctions.Unbind(story);
    }

    private void OnEnable()
    {
        GameEvents.current.DialogueEventsScr.onEnterDialogue += EnterDialogue;
        GameEvents.current.DialogueEventsScr.onUpdateChoiceIndex += UpdateChoiceIndex;
    }

    private void OnDisable()
    {
        GameEvents.current.DialogueEventsScr.onEnterDialogue -= EnterDialogue;
        GameEvents.current.DialogueEventsScr.onUpdateChoiceIndex -= UpdateChoiceIndex;
    }

    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialoguePlaying)
            {
                return;
            }

            ContinueOrExitStory();
        }
    }

    private void EnterDialogue(string knotName)
    {
        if (dialoguePlaying)
        {
            return;
        }

        dialoguePlaying = true;

        GameEvents.current.DialogueEventsScr.DialogueStarted();

        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }
        else
        {
            UnityEngine.Debug.LogWarning("name empty");
        }

        ContinueOrExitStory();
    }

    private void ContinueOrExitStory()
    {
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);

            currentChoiceIndex = -1;
        }
        if(story.canContinue)
        {
            string dialogueLine = story.Continue();
            HandleTags(story.currentTags);

            while(IsLineBlank(dialogueLine) && story.canContinue)
            {
                dialogueLine = story.Continue();
            }

            if (IsLineBlank(dialogueLine) && story.canContinue)
            {
                ExitDialogue();
            }
            else
            { 
                GameEvents.current.DialogueEventsScr.DisplayDialogue(dialogueLine, story.currentChoices); 
            }
        }
        else if (story.currentChoices.Count == 0)
        {
            StartCoroutine(ExitDialogue());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            if(splitTag.Length != 2)
            {
                UnityEngine.Debug.LogWarning("Tag could not be parsed " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case PORTRAIT_TAG:
                    GameEvents.current.DialogueEventsScr.DisplayPortrait(tagValue);
                    break;
                case ANNOYANCE_TAG:
                    string[] splitAnnoy = tagValue.Split("!");

                    string annoyStr = splitAnnoy[0].Trim();
                    string codeA = splitAnnoy[1].Trim();
                    int annoyInt = int.Parse(annoyStr);


                    if (codeA.Equals("s"))
                    {
                        GameEvents.current.RelationshipEventsScr.UpdateAnnoyanceSha(annoyInt);
                    }

                    if (codeA.Equals("r"))
                    {
                        GameEvents.current.RelationshipEventsScr.UpdateAnnoyanceRom(annoyInt);
                    }

                    break;
                case TRUST_TAG:
                    string[] splitTrust = tagValue.Split('!');

                    string trustStr = splitTrust[0].Trim();
                    string codeT = splitTrust[1].Trim();
                    int trustInt = int.Parse(trustStr);


                    if (codeT.Equals("s"))
                    {
                        GameEvents.current.RelationshipEventsScr.UpdateTrustSha(trustInt);
                    }

                    if(codeT.Equals("r"))
                    {
                        GameEvents.current.RelationshipEventsScr.UpdateTrustRom(trustInt);
                    }

                    break;
                default:
                    UnityEngine.Debug.LogWarning("Tag not recognised " + tag);
                    break;
            }
        }
    }

    private IEnumerator ExitDialogue()
    {
        yield return null;

        UnityEngine.Debug.Log("Exiting dialogue");

        dialoguePlaying = false;

        GameEvents.current.DialogueEventsScr.DialogueFinished();

        story.ResetState();
    }

    private bool IsLineBlank(string dialogueLine)
    {
        return dialogueLine.Trim().Equals("") || dialogueLine.Trim().Equals("\n");
    }
}
