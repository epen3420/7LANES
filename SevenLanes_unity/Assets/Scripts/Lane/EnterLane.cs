using UnityEngine;

public class EnterLane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var laneCount = LaneCreator.instance.LaneCount;
        other.GetComponent<CharaMove>().forwardSpeed = 10.0f + Mathf.Pow(1.1f, laneCount - 1) + 0.3f * laneCount - 0.3f;
    }
}
