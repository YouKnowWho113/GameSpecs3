using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomPomDebug : MonoBehaviour
{
    public Transform crown;
    public float sway = 30f;     // RẤT LỚN để debug
    public float damping = 1.5f; // Ít damping để thấy rõ

    float lastY;
    float velocity;

    void Start()
    {
        lastY = crown.eulerAngles.y;
    }

    void LateUpdate()
    {
        float currentY = crown.eulerAngles.y;
        float delta = Mathf.DeltaAngle(lastY, currentY);

        velocity += delta;
        velocity *= Mathf.Exp(-damping * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(0, velocity * sway, 0);

        lastY = currentY;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            transform.position,
            transform.position + transform.right * 0.05f
        );
    }
}
