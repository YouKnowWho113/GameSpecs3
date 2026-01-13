using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    public Camera targetCamera;
    public float verticalFOV = 60f;

    void Start()
    {
        if (targetCamera == null)
        {
            Debug.LogError("Camera not assigned");
            return;
        }

        targetCamera.fieldOfView = verticalFOV;
        targetCamera.ResetAspect(); 
    }
}