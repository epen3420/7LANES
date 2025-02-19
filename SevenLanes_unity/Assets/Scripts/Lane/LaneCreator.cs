using UnityEngine;

public class LaneCreator : MonoBehaviour
{
    private GameObject lanePrefab;
    public GameObject LanePrefab
    {
        set { lanePrefab = value; }
    }
    [SerializeField]
    private float laneDistance = 10.0f;

    private Vector3 nextLanePos = Vector3.zero;


    public void ExpandLane()
    {
        nextLanePos.z += laneDistance;
        // レーン生成は不透明度を上げる感じで出すから修正する
        Instantiate(lanePrefab, nextLanePos, Quaternion.identity);
    }
}
