using UnityEngine;

public class LaneCreator : MonoBehaviour
{
    public static LaneCreator instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private Vector3 nextLanePos;
    private Quaternion laneRotate = Quaternion.Euler(90, 0, 0);

    [SerializeField]
    private GameObject lanePrefab;
    public int LaneCount { get; private set; } = 0;//現在の生成したレーンの数
    float distance = 330f;
    private void Start()
    {
        nextLanePos = transform.position;
        LaneCount++;

    }
    //長さが現在の何倍になるか
    private float LengthFactor(int lanecount)
    {
        return Mathf.Pow(1.15f, lanecount) + 0.3f * (float)lanecount;
    }
    public void CountLane()
    {
        LaneCount++;
    }

    public void ExpandLane()
    {

        //次の生成位置
        nextLanePos.z += distance * LengthFactor(LaneCount - 1) + distance * LengthFactor(LaneCount);
        Debug.Log($"距離：{LengthFactor(LaneCount)}");
        Debug.Log($"生成位置：{nextLanePos.z}");
        GameObject lane = Instantiate(lanePrefab, nextLanePos, laneRotate);
        lane.transform.localScale = new Vector3(1, 62.5f * LengthFactor(LaneCount), 1); // 62.5f初期のレーンの長さ
        Debug.Log("レーンを延長しました");


        Transform starTransform = lane.transform.Find("Star");
        if (starTransform != null)
        {
            Renderer starRenderer = starTransform.GetComponent<Renderer>();
            if (starRenderer != null)
            {
                // 元のタイリングに倍率を掛ける（例：Yだけ調整）
                Vector2 tiling = starRenderer.material.mainTextureScale;
                tiling.y = 5.775f * LengthFactor(LaneCount + 1);
                starRenderer.material.mainTextureScale = tiling;
            }
        }
    }



}
