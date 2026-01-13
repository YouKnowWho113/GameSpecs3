using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomPomJiggle : MonoBehaviour
{
    public Transform crown;

    public float sway = 25f;
    public float follow = 2f;
    public float noise = 2f;

    float velocity;
    float lastY;
    Quaternion baseRot;
    float phaseOffset;

    void Start()
    {
        baseRot = transform.localRotation;
        lastY = crown.eulerAngles.y;
        phaseOffset = Random.Range(0f, 100f);

        sway *= Random.Range(0.8f, 1.2f);
        noise *= Random.Range(0.7f, 1.3f);
        follow *= Random.Range(0.9f, 1.1f);
    }

    void LateUpdate()
    {
        float currentY = crown.eulerAngles.y;
        float delta = Mathf.DeltaAngle(lastY, currentY);

        velocity += delta * follow;
        velocity *= 0.92f;

        float jiggle =
            velocity * sway +
            Mathf.Sin(Time.time * 6f + phaseOffset) * noise;

        transform.localRotation =
            baseRot * Quaternion.Euler(0, 0, jiggle);

        lastY = currentY;
    }


    void OnDrawGizmos()
    {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(
                transform.position,
                transform.position + transform.up * 0.1f
            );
    }
}