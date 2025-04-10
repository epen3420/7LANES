using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class StageFader : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void FadeIn(float fadeDuration)
    {
        StartCoroutine(FadeInCoroutine(fadeDuration));
    }

    private IEnumerator FadeInCoroutine(float fadeDuration)
    {
        Color originalColor = sr.color;
        float startAlpha = 0f;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, 1f, elapsed / fadeDuration);
            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // 完全に表示
    }
}
