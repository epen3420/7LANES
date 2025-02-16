using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("追従するプレイヤー")]
    [SerializeField]
    private Transform targetPlayer;
    [Header("追従するYのオフセット")]
    [SerializeField]
    private float camYOffset = 5.0f;
    [Header("追従するZのオフセット")]
    [SerializeField]
    private float camZOffset = -7.5f;


    private void Awake()
    {
        if (targetPlayer == null)
        {
            Debug.LogWarning("Target player is not set. Please set the target player in the inspector.");
            enabled = false;
        }
        transform.position = new Vector3(0, targetPlayer.position.y + camYOffset, targetPlayer.position.z + camZOffset);
    }

    private void Update()
    {
        // xの位置は固定
        transform.position = new Vector3(transform.position.x, transform.position.y, targetPlayer.position.z + camZOffset);
    }
}
