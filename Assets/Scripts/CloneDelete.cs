using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDelete : MonoBehaviour
{
    public void ClearAll()
    {
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnedObject");

        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
    }
}
