using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaMove : MonoBehaviour
{
    private const string KEY_MOVE_ACTION = "KeyMove"; // キーボード入力のアクション名
    private const string POINTER_MOVE_ACTION = "PointerMove"; // タップ入力のアクション名
    private InputSystem_Actions inputActions;
    private float screenCenter;
    private bool isSideMoving = false;

    [Header("横移動にかける時間")]
    [SerializeField]
    private float sideDuration = 1.0f;
    [Header("レーン間の距離")]
    [SerializeField]
    private float lanesDistance = 2.0f;
    [Header("前進の速度")]
    [SerializeField]
    private float forwardSpeed = 5.0f;


    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        screenCenter = Screen.width / 2;
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.KeyMove.performed += MoveSide;
        inputActions.Player.PointerMove.performed += MoveSide;
    }

    private void OnDisable()
    {
        inputActions.Player.KeyMove.performed -= MoveSide;
        inputActions.Player.PointerMove.performed -= MoveSide;

        inputActions.Disable();
    }

    private void Update()
    {
        // 前に移動
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 入力を検知
    /// </summary>
    /// <param name="context"></param>
    private void MoveSide(InputAction.CallbackContext context)
    {
        float inputValue = context.ReadValue<float>();
        switch (context.action.name)
        {
            case KEY_MOVE_ACTION:
                StartCoroutine(ChangeLane(inputValue));
                break;
            case POINTER_MOVE_ACTION:
                StartCoroutine(ChangeLane(PointerPos(inputValue)));
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ポインターの位置が画面中央より左か右かを判定する
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private int PointerPos(float pos)
    {
        return (int)Mathf.Sign(pos - screenCenter);
    }

    /// <summary>
    /// 方向によってLerpで移動する
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private IEnumerator ChangeLane(float direction)
    {
        if (isSideMoving) yield break;
        isSideMoving = true;

        float elapsedTime = 0.0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x + direction * lanesDistance, startPos.y, startPos.z);
        while (elapsedTime < sideDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / sideDuration;
            float newXPos = Mathf.Lerp(startPos.x, endPos.x, t);

            transform.position = new Vector3(newXPos, transform.position.y, transform.position.z); ;

            yield return null;
        }

        isSideMoving = false;
    }
}
