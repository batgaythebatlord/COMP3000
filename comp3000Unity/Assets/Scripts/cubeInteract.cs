using UnityEngine;

public class cubeInteract : MonoBehaviour
{
    [SerializeField] private string dialogueKnotName;
    private bool inRange = false;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    private void SubmitPressed()
    {
        if(!dialogueKnotName.Equals(""))
        {
            GameEvents.current.DialogueEventsScr.EnterDialogue(dialogueKnotName);
            UnityEngine.Debug.Log(dialogueKnotName);
        }

    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) & (inRange))
        {
            SubmitPressed();
        }
    }
}
