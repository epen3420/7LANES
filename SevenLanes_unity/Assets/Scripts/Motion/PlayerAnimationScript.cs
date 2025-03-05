using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationScript : MonoBehaviour
{
    private Animator anim;

    private GameObject playerObject;

    private SoundScript soundScript;
    private EssenceGetScript essenceGetScript;
    private int frameCounter = 0;   // 周期内における現在のフレーム
    private int totalFrames = 24;  // モーションの一周期のフレーム数

    private void Awake()
    {
        anim = GetComponent<Animator>();
        soundScript = GetComponent<SoundScript>();
        essenceGetScript = GetComponent<EssenceGetScript>();
        playerObject = GameObject.Find("Player");
    }
    private void Update()
    {
        // 毎フレームカウントを進める
        frameCounter = (frameCounter + 1) % totalFrames;
    }


    public void StartDrawing()
    {
        if (essenceGetScript.RainbowArrowCount > 0)
        {
            float normalizedTime = (float)frameCounter / (float)totalFrames;

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




    public void StopDrawing()
    {
        if (essenceGetScript.RainbowArrowCount > 0)
        {
            float normalizedTime = (float)frameCounter / (float)totalFrames;

            soundScript.StopKeepDrawingSE();
            soundScript.ShootingArrowSE(); // 矢を放つ音を再生する

            // アニメーションを切り替え
            anim.CrossFade("player_ShootArrow", 0.05f, 0, normalizedTime);
            Debug.Log("Stop Drawing: player_ShootArrow");
        }
    }
}
