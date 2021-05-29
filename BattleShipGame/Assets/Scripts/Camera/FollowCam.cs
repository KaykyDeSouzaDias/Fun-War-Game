using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Range(1,10)]
    public float smoothFactor;

    public Transform Char;

    public Vector3 offset;

    void FixedUpdate()
    {
        if (Char != null)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 targetPosition = Char.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
