using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Target to follow (e.g., the player)
    public Vector3 offset;         // Offset from the target
    public float smoothSpeed = 0.125f;  // Smoothing speed

    public bool doLookAt = false;

    //Transform.Translate and Lerp

    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Optionally, look at the target
        if(doLookAt)
            transform.LookAt(target);
    }
}
