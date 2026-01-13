using System.Collections;
using System.Collections.Generic;
using Leap;
using UnityEngine;

public class MaskRotate : MonoBehaviour
{
    [Header("Hand Transforms")]
    public Transform leftPalm;
    public Transform rightPalm;

    public Transform mask;

    public float rotationSpeed = 300f;
    public float deadZone = 0.001f;

    float lastLeftX;
    float lastRightX;
    bool hasLeft = false;
    bool hasRight = false;

    void Update()
    {
        
        if (leftPalm != null)
        {
            float currentX = leftPalm.position.x;

            if (!hasLeft)
            {
                lastLeftX = currentX;
                hasLeft = true;
            }
            else
            {
                float deltaX = currentX - lastLeftX;

                
                if (deltaX > deadZone)
                {
                    mask.Rotate(Vector3.up, -deltaX * rotationSpeed, Space.World);
                }

                lastLeftX = currentX;
            }
        }

        
        if (rightPalm != null)
        {
            float currentX = rightPalm.position.x;

            if (!hasRight)
            {
                lastRightX = currentX;
                hasRight = true;
            }
            else
            {
                float deltaX = currentX - lastRightX;

                
                if (deltaX < -deadZone)
                {
                    mask.Rotate(Vector3.up, -deltaX * rotationSpeed, Space.World);
                }

                lastRightX = currentX;
            }
        }
    }
}