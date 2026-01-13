using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public Renderer boxRenderer;

    [Header("Colors")]
    public Color normalColor = Color.gray;
    public Color thumbsUpColor = Color.red;

    [Header("Fade Settings")]
    public float fadeSpeed = 3f;

    private Color targetColor;

    void Start()
    {
        targetColor = normalColor;
        boxRenderer.material.color = normalColor;
    }

    void Update()
    {
        boxRenderer.material.color =
            Color.Lerp(
                boxRenderer.material.color,
                targetColor,
                Time.deltaTime * fadeSpeed
            );
    }

    // Called by Pose Detected
    public void SetThumbsUpColor()
    {
        targetColor = thumbsUpColor;
    }

    // Called by Pose Lost
    public void ResetColor()
    {
        targetColor = normalColor;
    }
}