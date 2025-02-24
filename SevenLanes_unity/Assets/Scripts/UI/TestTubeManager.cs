using UnityEngine;
using UnityEngine.UI;

public class TestTubeManager : MonoBehaviour
{
    [SerializeField]
    private InksManager[] inksManager;

    public void AddEssenceToTestTube(int essenceIndex)
    {
        inksManager[essenceIndex].AddInkToTestTube();
    }

    public void RemoveEssenceFromTestTube(int essenceIndex)
    {
        inksManager[essenceIndex].RemoveInkFromTestTube();
    }

    public void TransparentTestTube()
    {
        foreach (var ink in inksManager)
        {
            ink.TransparentInk();
        }
        var transparentImage = new TransParentImage();
        StartCoroutine(transparentImage.HideImage(GetComponent<Image>()));
    }
}
