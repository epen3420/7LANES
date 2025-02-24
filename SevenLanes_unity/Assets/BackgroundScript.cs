using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float duration = 40f; // 移動にかかる時間（秒）
    public float distance = -70f; // 移動距離（ローカルY軸方向）
    
    private Vector3 startPosition; // 初期位置
    private Vector3 targetPosition; // 目標位置
    private float elapsedTime = 0f; // 経過時間

    private void Start()
    {
        startPosition = transform.localPosition;
        targetPosition = startPosition + new Vector3(0, distance, 0); // Y軸下方向へ移動
    }

    private void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // 進行度（0.0～1.0）
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
        }
    }
}
