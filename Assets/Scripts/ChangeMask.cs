using System.Collections;
using System.Collections.Generic;
using Leap;
using UnityEngine;

public class ChangeMask : MonoBehaviour
{
    [Header("Materials Pool")]
    public Material[] materialPool;          // 0 1 2 3 (your 4 materials)
    public Renderer targetRenderer;          // Mask renderer

    [Header("Fade Settings")]
    public float fadeDuration = 0.6f;        // Speed of fade

    Color originalColor;
    int currentIndex = -1;
    bool isFading = false;

    [Header("Cooldown")]
    public float cooldownTime = 1f;     // 1 second cooldown
    bool onCooldown = false;

    void Start()
    {
        if (targetRenderer == null) targetRenderer = GetComponent<Renderer>();
        originalColor = targetRenderer.material.color;
    }

    // 🚀 Called by Ultraleap: HAND POSE DETECTOR (Thumbs Up)
    public void SetThumbsUpColor()
    {
        if (isFading || onCooldown) return; // avoid spam or too fast

        onCooldown = true;
        StartCoroutine(CooldownRoutine());

        currentIndex = (currentIndex + 1) % materialPool.Length;
        Debug.Log("Pose Detected → Switch to Material Index: " + currentIndex);

        StartCoroutine(FadeToMaterial(materialPool[currentIndex]));
    }


    // 🎯 Called when pose lost (optional)


    // 🌈 Fade Coroutine
    System.Collections.IEnumerator FadeToMaterial(Material newMat, bool reset = false)
    {
        isFading = true;

        Material oldMat = targetRenderer.material;
        Material nextMat = reset ? materialPool[0] : newMat;

        float time = 0f;
        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            targetRenderer.material.Lerp(oldMat, nextMat, t);
            time += Time.deltaTime;
            yield return null;
        }

        targetRenderer.material = nextMat;
        isFading = false;
    }

    IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        onCooldown = false;
    }
}