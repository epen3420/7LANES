using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationScript : MonoBehaviour
{
    private Animator anim;
    private InputSystem_Actions controls; // Input Systemのカスタムアクション
    private GameObject playerObject;
    private EssenceGetScript essenceGetScript;
    private SoundScript soundScript;
    private int frameCounter = 0;   // 周期内における現在のフレーム
    private int totalFrames = 24;  // モーションの一周期のフレーム数

    private void Awake()
    {
        anim = GetComponent<Animator>();
        soundScript = GetComponent<SoundScript>();
        controls = new InputSystem_Actions(); // Input Systemのアクションマップを作成
        playerObject = GameObject.Find("Player");
        essenceGetScript = playerObject.GetComponent<EssenceGetScript>();

        // Sキーが押されたときに弓を引く
        controls.Player.DrawBow.performed += ctx => StartDrawing();
        // Sキーが離されたときに弓を戻す
        controls.Player.DrawBow.canceled += ctx => StopDrawing(ctx);
    }
    private void Update()
    {
        // 毎フレームカウントを進める
        frameCounter = (frameCounter + 1) % totalFrames;

        // デバッグ用: 現在のアニメーション状態を確認
        Debug.Log("Current Animation: " + anim.GetCurrentAnimatorStateInfo(0).IsName("player_DrawaBow"));
    }

    private void OnEnable()
    {
        controls.Enable(); // Inputアクションを有効化
        controls.Player.DrawBow.canceled += StopDrawing;
    }

    private void OnDisable()
    {
        controls.Player.DrawBow.canceled -= StopDrawing;
        controls.Disable(); // Inputアクションを無効化
    }

    private void StartDrawing()
    {
        float normalizedTime = (float)frameCounter / (float)totalFrames;
        if (essenceGetScript.RainbowArrowCount > 0)
        {
            soundScript.StartDrawingSE();
            soundScript.KeepDrawingSE();

            // アニメーションを開始
            anim.CrossFade("player_DrawaBow", 0.05f, 0, normalizedTime);
            Debug.Log("Start Drawing: player_DrawaBow");
        }
        else
        {
            soundScript.NGDrawBowSE();
        }
    }

    private void StopDrawing(InputAction.CallbackContext ctx)
    {
        float normalizedTime = (float)frameCounter / (float)totalFrames;
        if (essenceGetScript.RainbowArrowCount > 0)
        {
            soundScript.StopKeepDrawingSE();
            soundScript.ShootingArrowSE(); // 矢を放つ音を再生する

            // アニメーションを切り替え
            anim.CrossFade("player_ShootArrow", 0.05f, 0, normalizedTime);
            Debug.Log("Stop Drawing: player_ShootArrow");
        }
    }
}
