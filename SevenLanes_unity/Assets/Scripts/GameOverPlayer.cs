using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPlayer : MonoBehaviour
{
    [SerializeField]
    private CharaMove charaMove;
    [SerializeField]
    private RainbowArrowUIManager rainbowArrowUIManager;
    [SerializeField]
    private TestTubeManager testTubeManager;


    public IEnumerator GameOver(SpriteRenderer laneSpriteRenderer)
    {
        GetComponent<PlayerInputManager>().enabled = false;
        yield return new WaitForSeconds(1.0f);
        charaMove.StopChara();
        TransParentsUI();
        yield return new WaitForSeconds(1.0f);

        var animator = GetComponent<Animator>();
        animator.enabled = false;
        yield return new WaitForSeconds(2.0f);
        animator.enabled = true;
        animator.SetBool("IsGameOver", true);
        yield return new WaitForSeconds(1.0f);
        laneSpriteRenderer.sortingLayerName = "Lane";
        charaMove.FallDown();
    }

    private void TransParentsUI()
    {
        rainbowArrowUIManager.TransparentRainbowArrow();
        testTubeManager.TransparentTestTube();
    }
}
