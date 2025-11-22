using UnityEngine;
using TMPro;
using System.Collections;

public class TextFade : MonoBehaviour
{
    [Header("Fade Timing")]
    public float fadeInDuration = 0.3f;
    public float visibleDuration = 1.0f;
    public float fadeOutDuration = 0.5f;

    [Header("Movement")]
    public float moveUpDistance = 2f;  // in UI units (pixels)

    [Header("Behavior")]
    public bool disableOnEnd = true;

    private TMP_Text tmpText;
    private RectTransform rectTransform;
    private Coroutine routine;

    void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
        rectTransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        if (routine != null)
            StopCoroutine(routine);

        routine = StartCoroutine(FadeAndFloat());
    }

    IEnumerator FadeAndFloat()
    {
        Color baseColor = tmpText.color;

        // Capture starting UI position *when* it appears
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = startPos + Vector2.up * moveUpDistance;

        float totalTime = fadeInDuration + visibleDuration + fadeOutDuration;
        float elapsed = 0f;

        // start invisible
        {
            Color c = baseColor;
            c.a = 0f;
            tmpText.color = c;
        }

        while (elapsed < totalTime)
        {
            elapsed += Time.deltaTime;
            float moveT = Mathf.Clamp01(elapsed / totalTime);

            // --- Move upward over entire lifetime ---
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, moveT);

            // --- Handle fading ---
            if (elapsed <= fadeInDuration)
            {
                // Fade in 0 → 1
                float t = Mathf.Clamp01(elapsed / fadeInDuration);
                Color c = baseColor;
                c.a = t;
                tmpText.color = c;
            }
            else if (elapsed <= fadeInDuration + visibleDuration)
            {
                // Fully visible
                Color c = baseColor;
                c.a = 1f;
                tmpText.color = c;
            }
            else
            {
                // Fade out 1 → 0
                float t = (elapsed - fadeInDuration - visibleDuration) / fadeOutDuration;
                t = Mathf.Clamp01(t);

                Color c = baseColor;
                c.a = 1f - t;
                tmpText.color = c;
            }

            yield return null;
        }

        // Force final state: fully faded, at end position
        rectTransform.anchoredPosition = endPos;

        {
            Color c = baseColor;
            c.a = 0f;
            tmpText.color = c;
        }

        if (disableOnEnd)
            gameObject.SetActive(false);

        routine = null;
    }
}
