using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPerson : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public float smoothSpeed = 0.125f;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;

    void Start()
    {
        locationOffset = new Vector3(5, 5, -5);
        rotationOffset = new Vector3(45, -45, 0);
    }

    //don't want this exactly, want DE style camera instead
    void FixedUpdate()
    {
        Vector3 desiredPosition = target1.position + target2.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredrotation = target2.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;
    }
}
