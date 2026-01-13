using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingMask1s : MonoBehaviour
{
    [Header("Materials Pool")]
    public Material[] materialPool;
    public Renderer targetRenderer;

    [Header("Auto Cycle Settings")]
    public float changeInterval = 1f;
    public bool autoStart = true;

    int currentIndex = -1;
    bool isRunning = false;
    Coroutine autoRoutine;

    void Start()
    {
        if (autoStart)
            StartAutoCycle();
    }

    // ===== AUTO =====
    public void StartAutoCycle()
    {
        if (isRunning || materialPool.Length == 0) return;

        isRunning = true;
        autoRoutine = StartCoroutine(AutoChange());
    }

    public void StopAutoCycle()
    {
        if (!isRunning) return;

        StopCoroutine(autoRoutine);
        isRunning = false;
    }

    IEnumerator AutoChange()
    {
        while (true)
        {
            ChangeMaterial();
            yield return new WaitForSeconds(changeInterval);
        }
    }

    // ===== MANUAL (BUTTON CŨ VẪN GỌI ĐƯỢC) =====
    public void ChangeMaterial()
    {
        currentIndex = (currentIndex + 1) % materialPool.Length;
        targetRenderer.material = materialPool[currentIndex];
    }
}
