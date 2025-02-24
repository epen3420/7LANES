using UnityEngine;
using UnityEngine.UI;

public class InksManager : MonoBehaviour
{
    private int inkIndex = 0;

    [SerializeField]
    private GameObject[] inksInTestTube;
    [SerializeField]
    private Image testTube;


    private void Start()
    {
        foreach (var ink in inksInTestTube)
        {
            ink.SetActive(false);
        }
    }

    public void AddInkToTestTube()
    {
        if (inkIndex < inksInTestTube.Length)
        {
            inksInTestTube[inkIndex].SetActive(true);
            inkIndex++;
        }
    }

    public void RemoveInkFromTestTube()
    {
        if (inkIndex > 0)
        {
            inkIndex--;
            inksInTestTube[inkIndex].SetActive(false);
        }
    }

    public void TransparentInk()
    {
        var transparentImage = new TransParentImage();
        foreach (var ink in inksInTestTube)
        {
            StartCoroutine(transparentImage.HideImage(ink.GetComponent<Image>()));
        }
        StartCoroutine(transparentImage.HideImage(testTube));
    }
}
