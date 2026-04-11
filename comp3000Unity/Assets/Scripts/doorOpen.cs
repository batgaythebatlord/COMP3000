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
        if (other.gameObject.tag == "Player")
        {
            target1.transform.Translate(Vector3.left);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target1.transform.Translate(Vector3.right);
        }
    }
}
