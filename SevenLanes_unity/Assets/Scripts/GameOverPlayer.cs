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


    private void Update()
    {
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }

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
        animator.speed = 5.0f;
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
