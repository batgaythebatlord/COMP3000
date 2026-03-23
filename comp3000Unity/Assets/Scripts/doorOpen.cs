using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public Transform target1;
    Vector3 myVector;

    void Start()
    {
        myVector = new Vector3(0.0f, 0.0f, 0.25f);
    }

    void OnTriggerEnter(Collider other)
    {
        Open();
    }

    void OnTriggerExit(Collider other)
    {
        Close();
    }

    void Open()
    {
        //move over by like 4?
        //make both animations later

        target1.transform.Translate(Vector3.left);
    }

    void Close()
    {
        //move back
        target1.transform.Translate(Vector3.right);
    }
}
