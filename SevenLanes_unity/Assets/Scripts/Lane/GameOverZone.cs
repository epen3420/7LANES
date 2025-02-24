using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("Game Over");
        }
    }
}
