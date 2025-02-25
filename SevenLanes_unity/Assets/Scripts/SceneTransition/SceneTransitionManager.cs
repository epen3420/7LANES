using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private GameObject loadObj; // ロード画面全体 (黒背景を含む)
    [SerializeField] private Image loadBackground; // 黒い背景用のImage
    [SerializeField] private float fadeDuration = 1.5f;

    public void LoadScreen(string sceneName)
    {
        loadObj.SetActive(true); // 黒い画面を表示
        StartCoroutine(LoadNextScene(sceneName));
    }

    private IEnumerator LoadNextScene(string sceneName)
    {
        yield return StartCoroutine(FadeOut());

        // シーンを非アクティブのままロードする
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // シーン遷移が終わるまでロード画面を保持
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        for (float t = 0; t <= fadeDuration; t += Time.deltaTime)
        {
            float alpha = t / fadeDuration;
            loadBackground.color = new Color(0, 0, 0, alpha); // 黒フェード
            yield return null;
        }
    }
}
