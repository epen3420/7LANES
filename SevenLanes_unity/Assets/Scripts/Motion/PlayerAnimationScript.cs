using UnityEngine;
using UnityEngine.InputSystem;



//弓矢のアニメーションと付随する弓矢SEを再生するスクリプト

public class PlayerAnimationScript : MonoBehaviour
{
    private Animator anim;

    private GameObject playerObject;

    private EssenceGetScript essenceGetScript;
    private BowArrowSEScript bowArrowSEScript;
    private int frameCounter = 0;   //周期内における現在のフレーム

    private int totalFrames = 24;  // モーションの一周期のフレーム数

    private void Awake()
    {
        anim = GetComponent<Animator>();

        bowArrowSEScript = GetComponent<BowArrowSEScript>();
       // controls = new InputSystem_Actions(); // Input Systemのアクションマップを作成

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
            bowArrowSEScript.StartDrawingSE();

            bowArrowSEScript.KeepDrawingSE();
            // 直前のアニメーションの位置を保持してスムーズな遷移を行う

            anim.CrossFade("player_DrawaBow", 0.05f, 0, normalizedTime);
            Debug.Log("Start Drawing: player_DrawaBow");
        }
        else
        {
            bowArrowSEScript.NGDrawBowSE();
        }
    }

    public void StopDrawing()
    {
        if (essenceGetScript.RainbowArrowCount > 0)
        {
            float normalizedTime = (float)frameCounter / (float)totalFrames;
            bowArrowSEScript.StopKeepDrawingSE();
            bowArrowSEScript.ShootingArrowSE();//矢を放つ音を再生する
            // 滑らかにアニメーションを切り替え

            anim.CrossFade("player_ShootArrow", 0.05f, 0, normalizedTime);
            Debug.Log("Stop Drawing: player_ShootArrow");
        }
    }
}
