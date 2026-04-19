using UnityEngine;
using Ink.Runtime;
using System;

public class dialogueManager : MonoBehaviour
{
    [SerializeField] private TextAsset inkJson;

    private Story story;

    private bool dialoguePlaying = false;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }

    private void OnEnable()
    {
        GameEvents.current.DialogueEventsScr.onEnterDialogue += EnterDialogue;
    }

    private void OnDisable()
    {
        GameEvents.current.DialogueEventsScr.onEnterDialogue -= EnterDialogue;
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

        if(!knotName.Equals(""))
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
        if(story.canContinue)
        {
            string dialogueLine = story.Continue();

            UnityEngine.Debug.Log(dialogueLine);
        }
        else
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        UnityEngine.Debug.Log("Exiting dialogue");

        dialoguePlaying = false;

        story.ResetState();
    }
}
