using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 offset, newPosition;
    public float lerp;
    
    private void Start()
    {
        offset = transform.position - PlayerTransform.position;
    }

    private void LateUpdate()
    {
        cameraMove();
    }

    private void cameraMove()
    {
        newPosition = Vector3.Lerp(transform.position, PlayerTransform.position + offset, lerp * Time.deltaTime);
        transform.position = newPosition;
    }
}
