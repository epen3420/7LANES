using UnityEngine;

public class InLaneChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<EssenceGetScript>().CanExpandLane = true;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<EssenceGetScript>().CanExpandLane = false;

        StartCoroutine(other.GetComponent<GameOverPlayer>().GameOver());
        transform.root.GetComponent<SpriteRenderer>().sortingLayerName = "Lane";
    }
}
