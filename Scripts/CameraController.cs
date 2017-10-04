﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    public bool lookAt;

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        transform.position = target.position + offsetPosition;

        if (lookAt)
        {
            transform.position = target.position + offsetPosition;
        }
        else
        {
            transform.position = target.TransformPoint(offsetPosition);
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            //float moveHorizontal = Input.GetAxis("Horizontal");

            //transform.Rotate(Vector3.up, moveHorizontal * 40 * Time.deltaTime);

            float mouseHorizontal = Input.GetAxis("Mouse X");
            float mouseVertical = Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.up, mouseHorizontal);
            transform.Rotate(Vector3.right, -mouseVertical);
        }
    }
}