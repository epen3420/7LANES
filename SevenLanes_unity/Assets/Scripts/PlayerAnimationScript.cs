using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationScript : MonoBehaviour
{
    private Animator anim;
    private InputSystem_Actions controls; // Input Systemのカスタムアクション

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controls = new InputSystem_Actions(); // Input Systemのアクションマップを作成

        // Sキーが押されたときに弓を引く
        controls.Player.DrawBow.performed += ctx => StartDrawing();
        // Sキーが離されたときに弓を戻す
        controls.Player.DrawBow.canceled += ctx => StopDrawing();
    }

    private void OnEnable()
    {
        controls.Enable(); // Inputアクションを有効化
    }

    private void OnDisable()
    {
        controls.Disable(); // Inputアクションを無効化
    }

    private void StartDrawing()
    {
        anim.SetBool("isDrawingBow", true);
    }

    private void StopDrawing()
    {
        anim.SetBool("isDrawingBow", false);
    }
}
