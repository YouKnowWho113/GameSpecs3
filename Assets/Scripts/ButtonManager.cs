using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public CloneDelete clearScript;
    public GameObject maskPrefab;
    public Transform spawnPoint;

    public void OnButtonPressed()
    {
        // 1. XÓA TRƯỚC
        clearScript.ClearAll();

        // 2. SPAWN SAU
        Instantiate(maskPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
