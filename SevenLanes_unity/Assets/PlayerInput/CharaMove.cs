using UnityEngine;

public class CharaMove : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed = 5.0f;


    private void Update()
    {
        // 前に移動
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}
