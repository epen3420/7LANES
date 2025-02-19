using System.Collections;
using UnityEngine;

public class CharaMove : MonoBehaviour, IPlayerMovable
{
    private const float SIDE_MOVE_DURATION = 0.06f;
    private bool isSideMoving = false;

    [Header("レーン間の距離")]
    [SerializeField]
    private float lanesDistance = 2.0f;
    [Header("前進の速度")]
    [SerializeField]
    private float forwardSpeed = 5.0f;


    private void Update()
    {
        float currentFlameDistance = forwardSpeed * Time.deltaTime;
        // 前に移動
        transform.Translate(Vector3.forward * currentFlameDistance);
    }

    /// <summary>
    /// 方向によってLerpで移動する
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public IEnumerator ChangeLane(float direction)
    {
        if (isSideMoving) yield break;
        isSideMoving = true;

        float elapsedTime = 0.0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x + direction * lanesDistance, startPos.y, startPos.z);
        while (elapsedTime < SIDE_MOVE_DURATION)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / SIDE_MOVE_DURATION;

            Vector3 currentPos = transform.position;
            currentPos.x = Mathf.Lerp(startPos.x, endPos.x, t);

            transform.position = currentPos;

            yield return null;
        }

        isSideMoving = false;
    }
}
