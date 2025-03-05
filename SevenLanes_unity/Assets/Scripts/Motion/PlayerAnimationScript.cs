using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
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
    }
    /*
        private void OnEnable()
        {
            controls.Enable(); // Inputアクションを有効化

            // イベント登録（※重複しないように注意）
           controls.Player.DrawBow.performed += StartDrawing;
            controls.Player.DrawBow.canceled += StopDrawing;
        }

        private void OnDisable()
        {
            // イベント解除（必ず登録解除する）
            controls.Player.DrawBow.performed -= StartDrawing;
            controls.Player.DrawBow.canceled -= StopDrawing;

            controls.Disable(); // Inputアクションを無効化
        }
    */
    private void Update()
    {
        // 毎フレームカウントを進める
        frameCounter = (frameCounter + 1) % totalFrames;
        if (Input.GetKeyUp("s")||Input.GetKeyUp("DownArrow"))
        {

            float normalizedTime = (float)frameCounter / totalFrames;

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

        if (Input.GetKeyUp("s")||Input.GetKeyUp("DownArrow"))
        {

            float normalizedTime = (float)frameCounter / totalFrames;

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
    /* 
      private void StartDrawing(InputAction.CallbackContext ctx)
      {

          float normalizedTime = (float)frameCounter / totalFrames;

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

              float normalizedTime = (float)frameCounter / totalFrames;

              if (essenceGetScript.RainbowArrowCount > 0)
              {
                  soundScript.StopKeepDrawingSE();
                  soundScript.ShootingArrowSE(); // 矢を放つ音を再生する

                  // アニメーションを切り替え
                  anim.CrossFade("player_ShootArrow", 0.05f, 0, normalizedTime);
                  Debug.Log("Stop Drawing: player_ShootArrow");
              }
          }
          */
}
