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

        // isMove を false にする
        var background = FindObjectOfType<BackgroundScript>();
        if (background != null)
        {
            background.isMove = false;
            Debug.Log("背景停止（isMove = false）");
        }

        var gameOverPlayer = other.GetComponent<GameOverPlayer>();
        StartCoroutine(gameOverPlayer.GameOver(transform.root.GetComponent<SpriteRenderer>()));
    }
}
