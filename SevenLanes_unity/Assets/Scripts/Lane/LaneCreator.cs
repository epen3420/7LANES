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
    private float laneDistance = 465.0f;
    [SerializeField]
    private GameObject lanePrefab;
    public int LaneCount { get; private set; } = 0;

    private void Start()
    {
        nextLanePos = transform.position;
        LaneCount++;
    }

    public void ExpandLane()
    {
        nextLanePos.z += laneDistance;
        // レーン生成は不透明度を上げる感じで出すから修正する
        Instantiate(lanePrefab, nextLanePos, laneRotate);
        Debug.Log("レーンを延長しました");

        LaneCount++;
    }
}
