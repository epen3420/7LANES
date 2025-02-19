using UnityEngine;

public class InLaneChecker : MonoBehaviour
{
    private bool canExpandLane = false;
    private LaneCreator laneCreator = null;


    private void OnTriggerEnter(Collider other)
    {
        canExpandLane = !canExpandLane;

        GameObject player = other.gameObject;
        if (laneCreator == null)
        {
            player.AddComponent<LaneCreator>();
            laneCreator = player.GetComponent<LaneCreator>();
            laneCreator.LanePrefab = transform.root.gameObject;
        }
        laneCreator.enabled = canExpandLane;
    }
}
