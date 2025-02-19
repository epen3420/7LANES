using UnityEngine;

public class InLaneChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<EssenceGetScript>().CanExpandLane = true;
    }
}
