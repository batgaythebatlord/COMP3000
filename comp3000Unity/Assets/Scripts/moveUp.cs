using UnityEngine;

public class moveUp : MonoBehaviour
{
    public GameObject Player;
    public GameObject Interact;

    Vector3 myVector;

    void Start()
    {
        myVector = new Vector3(0.0f, 0.0f, 1.0f);
    }

    void OnTriggerStay(Collider other)
    {
        Interact.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.transform.Translate(Vector3.up);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Interact.SetActive(false);
    }
}
