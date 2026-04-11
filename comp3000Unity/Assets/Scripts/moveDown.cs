using UnityEngine;

public class moveDown : MonoBehaviour
{
    public GameObject Player;
    public GameObject Interact;

    Vector3 myVector;

    void Start()
    {
        myVector = new Vector3(0.0f, 0.0f, 0.25f);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.transform.Translate(Vector3.down);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interact.SetActive(false);
        }
    }
}
