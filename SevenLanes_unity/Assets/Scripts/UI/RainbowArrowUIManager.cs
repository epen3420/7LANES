using UnityEngine;

public class RainbowArrowUIManager : MonoBehaviour
{
    private int arrowIndex = 0;

    [SerializeField]
    private SwitchShowArrow[] arrows;


    public void ShowRainbowArrow()
    {
        if (arrowIndex > arrows.Length)
        {
            return;
        }
        arrows[arrowIndex].SwitchArrow();
        arrowIndex++;
    }

    public void HideRainbowArrow()
    {
        if (arrowIndex < 0)
        {
            return;
        }
        arrowIndex--;
        arrows[arrowIndex].SwitchArrow();
    }

    public void TransparentRainbowArrow()
    {
        foreach (var arrow in arrows)
        {
            arrow.TransparentArrow();
        }
    }
}
