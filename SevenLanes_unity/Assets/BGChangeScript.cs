using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// 背景キャンバスに付与
// 複数の画像を不透明度を徐々に上げていく
public class BGChangeScript : MonoBehaviour
{
    public Image[] backGrounds; // 複数の背景画像 (Imageコンポーネント)
    public float fadeDuration = 2.0f; // フェードインの時間（秒）
    private Coroutine fadeCoroutine; // フェード用のコルーチン管理

    private void Start()
    {
        // 初期状態を透明に設定
        for (int i = 1; i < backGrounds.Length; i++)
        {
            if (backGrounds[i] != null)
            {
                Color color = backGrounds[i].color;
                color.a = 0f;
                backGrounds[i].color = color;
                backGrounds[i].gameObject.SetActive(false);
            }
        }
    }

    public void ChangeBG(int index)
    {
        if (index < 0 || index >= backGrounds.Length)
        {
            Debug.LogError($"インデックス {index} が配列の範囲外です");
            return;
        }

        // 前回のフェードが残っている場合はキャンセル
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        // 画像を有効化してフェードイン開始
        backGrounds[index].gameObject.SetActive(true);
        fadeCoroutine = StartCoroutine(FadeIn(backGrounds[index]));
    }

    private IEnumerator FadeIn(Image targetImage)
    {
        float timer = 0f;
        Color color = targetImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            color.a = alpha;
            targetImage.color = color;

            yield return null; // 次のフレームまで待機
        }

        // 最終的に透明度を完全に1に設定
        color.a = 1f;
        targetImage.color = color;

        fadeCoroutine = null; // コルーチン終了
    }
}
