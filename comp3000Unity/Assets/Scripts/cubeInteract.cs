using UnityEngine;

public class cubeInteract : MonoBehaviour
{
    [SerializeField] private string dialogueKnotName;

    private void SubmitPressed()
    {
        if(!dialogueKnotName.Equals(""))
        {
            //GameEvents.instance.DialogueEventsScr.EnterDialogue(dialogueKnotName);
            //gotta understand why this isn't working
        }
    }
}
