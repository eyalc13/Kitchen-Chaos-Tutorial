using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Switch;

public class LookAtCamera : MonoBehaviour
{
    private enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwarsInverted,
    }

    [SerializeField] private Mode mode;
    private void LateUpdate()
    {
        switch(mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                Vector3 dirFormCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirFormCamera);
                break;
            case Mode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.CameraForwarsInverted:
                transform.forward = - Camera.main.transform.forward;
                break;
        }
    }
}
