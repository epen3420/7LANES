using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private const string KEY_MOVE_ACTION = "KeyMove"; // キーボード入力のアクション名
    private const string POINTER_MOVE_ACTION = "PointerMove"; // タップ入力のアクション名
    private CharaMove charaMove;
    private InputSystem_Actions inputActions;
    private float screenCenter;
    private bool isSideMoving = false;


    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        charaMove = GetComponent<CharaMove>();

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
                StartCoroutine(charaMove.ChangeLane(inputValue));
                break;
            case POINTER_MOVE_ACTION:
                StartCoroutine(charaMove.ChangeLane(PointerPos(inputValue)));
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
}
