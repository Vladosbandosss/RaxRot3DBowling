using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float distanse;
    public float height;
    public GameObject objectToFollow;

    private void LateUpdate()
    {
        if (objectToFollow == null)
        {
            return;
        }

        Vector3 destination = objectToFollow.transform.position;

        destination.x = 0f;
        destination.y += height;
        destination.z += distanse;

        transform.position = destination;
    }
}
