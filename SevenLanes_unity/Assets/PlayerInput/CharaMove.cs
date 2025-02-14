using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaMove : MonoBehaviour
{
    private const string KEY_MOVE_ACTION = "KeyMove";
    private const string POINTER_MOVE_ACTION = "PointerMove";
    private InputSystem_Actions inputActions;
    private float screenCenter;
    private bool isSideMoving = false;

    [SerializeField]
    private float sideDuration = 1.0f;
    [SerializeField]
    private float lanesDistance = 2.0f;
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
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / sideDuration);
            yield return null;
        }

        isSideMoving = false;
    }
}
