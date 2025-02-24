using UnityEngine;

public class InLaneChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<EssenceGetScript>().canExpandLane = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<EssenceGetScript>().canExpandLane)
        {
            return;
        }

        var gameOverPlayer = other.GetComponent<GameOverPlayer>();
        StartCoroutine(gameOverPlayer.GameOver(transform.root.GetComponent<SpriteRenderer>()));
    }
}
