using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PomPomManager : MonoBehaviour
{
    public GameObject hatAnchor; // HatTest
    public string pomPomTag = "PomPom";

    [ContextMenu("Setup All Pom-Poms")]
    public void SetupAllPomPoms()
    {
        if (hatAnchor == null)
        {
            Debug.LogError("HatAnchor not assigned!");
            return;
        }

        Rigidbody hatRb = hatAnchor.GetComponent<Rigidbody>();
        if (hatRb == null)
        {
            Debug.LogError("HatAnchor needs a Rigidbody!");
            return;
        }

        GameObject[] pomPomObjects = string.IsNullOrEmpty(pomPomTag)
            ? GameObject.FindObjectsOfType<SpringJoint>().Select(j => j.gameObject).ToArray()
            : GameObject.FindGameObjectsWithTag(pomPomTag);

        int count = 0;

        foreach (GameObject pom in pomPomObjects)
        {
            Rigidbody rb = pom.GetComponent<Rigidbody>();
            SpringJoint sj = pom.GetComponent<SpringJoint>();
            if (rb == null || sj == null) continue;

            // Store original spring/damper
            float origSpring = sj.spring;
            float origDamper = sj.damper;
            float origMaxDistance = sj.maxDistance;

            // Temporarily disable spring effect
            sj.spring = 0;
            sj.damper = 0;
            sj.maxDistance = 0;

            // Set connected body
            sj.connectedBody = hatRb;

            // Set connectedAnchor in local space
            sj.connectedAnchor = hatAnchor.transform.InverseTransformPoint(pom.transform.position);

            // Snap pom-pom exactly to the anchor position
            Vector3 worldAnchor = hatAnchor.transform.TransformPoint(sj.connectedAnchor);
            rb.position = worldAnchor;
            rb.rotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Restore spring settings
            sj.spring = origSpring;
            sj.damper = origDamper;
            sj.maxDistance = origMaxDistance;

            count++;
        }

        Debug.Log($"Pom-Pom setup complete! {count} SpringJoints connected to HatAnchor.");
    }
}