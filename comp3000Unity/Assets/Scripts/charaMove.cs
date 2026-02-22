using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaMove : MonoBehaviour
{
    Vector3 myVector;
    float speed = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        myVector = new Vector3(0.0f, 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -1.5f, 0.0f, Space.Self);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, 1.5f, 0.0f, Space.Self);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * (speed * 2));
        }



        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
