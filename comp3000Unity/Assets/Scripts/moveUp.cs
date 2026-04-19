using UnityEngine;
using UnityEngine.InputSystem;

public class moveUp : MonoBehaviour
{
    public GameObject Player;
    public GameObject Interact;

    Vector3 myVector;

    private bool inRange = false;

    void Start()
    {
        myVector = new Vector3(0.0f, 0.0f, 1.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
            Interact.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;    
            Interact.SetActive(false);
        }
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space)) & (inRange))
        {
            Player.transform.Translate((Vector3.up)*3.0f);
        }
    }
}
