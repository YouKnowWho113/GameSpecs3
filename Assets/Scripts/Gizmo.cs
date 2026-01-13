using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public Color anchorColor = Color.green;
    public Color connectedAnchorColor = Color.yellow;
    public Color lineColor = Color.white;
    public float sphereSize = 0.01f;

    void OnDrawGizmos()
    {
        SpringJoint sj = GetComponent<SpringJoint>();
        if (sj == null || sj.connectedBody == null) return;

        // Anchor world position
        Vector3 anchorWorld =
            transform.TransformPoint(sj.anchor);

        // Connected anchor world position
        Vector3 connectedAnchorWorld =
            sj.connectedBody.transform.TransformPoint(sj.connectedAnchor);

        // Draw anchor spheres
        Gizmos.color = anchorColor;
        Gizmos.DrawSphere(anchorWorld, sphereSize);

        Gizmos.color = connectedAnchorColor;
        Gizmos.DrawSphere(connectedAnchorWorld, sphereSize);

        // Draw line
        Gizmos.color = lineColor;
        Gizmos.DrawLine(anchorWorld, connectedAnchorWorld);
    }
}