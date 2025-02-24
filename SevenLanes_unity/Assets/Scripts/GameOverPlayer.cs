using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPlayer : MonoBehaviour
{
    [SerializeField]
    private Image[] uiImage;
    [SerializeField]
    private CharaMove charaMove;
    [SerializeField]
    private RainbowArrowUIManager rainbowArrowUIManager;
    [SerializeField]
    private TestTubeManager testTubeManager;


    public IEnumerator GameOver()
    {
        GetComponent<PlayerInputManager>().enabled = false;
        yield return new WaitForSeconds(1.0f);
        charaMove.StopChara();
        TransParentsUI();
        yield return new WaitForSeconds(1.0f);

        var animator = GetComponent<Animator>();
        animator.enabled = false;
        yield return new WaitForSeconds(1.0f);
        animator.enabled = true;
        animator.SetBool("IsGameOver", true);
        charaMove.FallDown();
    }

    private void TransParentsUI()
    {
        rainbowArrowUIManager.TransparentRainbowArrow();
        testTubeManager.TransparentTestTube();
    }
}
