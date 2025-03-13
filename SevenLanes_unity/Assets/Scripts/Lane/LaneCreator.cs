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

    private const float LANE_DISTANCE = 265.0f;
    private Vector3 nextLanePos = new Vector3(0, 0, 100);
    private Quaternion laneRotate = Quaternion.Euler(90, 0, 0);

    [SerializeField]
    private GameObject lanePrefab;
    public int LaneCount { get; private set; } = 0;

    private void Start()
    {
        LaneCount++;
    }

    public void ExpandLane()
    {
        nextLanePos.z += LANE_DISTANCE;
        // レーン生成は不透明度を上げる感じで出すから修正する
        Instantiate(lanePrefab, nextLanePos, laneRotate);
        Debug.Log("レーンを延長しました");

        LaneCount++;
    }
}
