using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private const string KEY_MOVE_ACTION = "KeyMove"; // キーボード入力のアクション名
    private const string POINTER_MOVE_ACTION = "PointerMove"; // タップ入力のアクション名
    private IPlayerMovable iPlayerMovable;
    private EssenceGetScript essenceGetScript;
    private InputSystem_Actions inputActions;
    private float screenCenter;


    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        iPlayerMovable = GetComponent<IPlayerMovable>();
        essenceGetScript = GetComponent<EssenceGetScript>();

        screenCenter = Screen.width / 2;
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.KeyMove.performed += MoveSide;
        inputActions.Player.PointerMove.performed += MoveSide;
        inputActions.Player.KeyCreateLane.performed += ShootRainbowArrow;
    }

    private void OnDisable()
    {
        inputActions.Player.KeyMove.performed -= MoveSide;
        inputActions.Player.PointerMove.performed -= MoveSide;
        inputActions.Player.KeyCreateLane.performed -= ShootRainbowArrow;

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
                StartCoroutine(iPlayerMovable.ChangeLane(inputValue));
                break;
            case POINTER_MOVE_ACTION:
                StartCoroutine(iPlayerMovable.ChangeLane(PointerPos(inputValue)));
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

    private void ShootRainbowArrow(InputAction.CallbackContext context)
    {
        essenceGetScript.ReleaseRainbowArrow();
    }
}
