using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpinningY : MonoBehaviour
{
    public float speed = 90f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(
            transform.position,
            transform.position + transform.forward * 0.1f
        );
    }
}
