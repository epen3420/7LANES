using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationScript : MonoBehaviour
{
    private Animator anim;
    private InputSystem_Actions controls; // Input Systemのカスタムアクション

    private int frameCounter = 0;   //周期内における現在のフレーム
    private int totalFrames = 24;  // モーションの一周期のフレーム数

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controls = new InputSystem_Actions(); // Input Systemのアクションマップを作成

        // Sキーが押されたときに弓を引く
        controls.Player.DrawBow.performed += ctx => StartDrawing();
        // Sキーが離されたときに弓を戻す
        controls.Player.DrawBow.canceled += ctx => StopDrawing();
    }
        private void Update()
    {
        // 毎フレームカウントを進める
        frameCounter = (frameCounter + 1) % totalFrames;
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
        float normalizedTime = (float)frameCounter / (float)totalFrames;
        
        // 直前のアニメーションの位置を保持してスムーズな遷移を行う
        anim.CrossFade("player_DrawaBow", 0.05f, 0, normalizedTime);
    }

    private void StopDrawing()
    {
        float normalizedTime = (float)frameCounter / (float)totalFrames;
        
        // 滑らかにアニメーションを切り替え
        anim.CrossFade("player_ShootArrow", 0.05f, 0, normalizedTime);

        
    }
}
