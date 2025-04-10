using UnityEngine;
using System.Collections;

public class StarFader : MonoBehaviour
{


    private Material starMaterial;

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // マテリアルのインスタンスを取得（共有でなく）
            starMaterial = renderer.material;
            SetMaterialTransparent(starMaterial);
        }
    }

    public void FadeIn(float fadeDuration)
    {
        StartCoroutine(FadeInCoroutine(fadeDuration));
    }

    private IEnumerator FadeInCoroutine(float fadeDuration)
    {
        Color color = starMaterial.color;
        float alpha = 0f;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(alpha, 1f, elapsed / fadeDuration);
            starMaterial.color = new Color(color.r, color.g, color.b, newAlpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 最終的に完全不透明にする
        starMaterial.color = new Color(color.r, color.g, color.b, 1f);
    }

    private void SetMaterialTransparent(Material mat)
    {
        mat.SetFloat("_Mode", 3); // Transparent
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;
    }
}
