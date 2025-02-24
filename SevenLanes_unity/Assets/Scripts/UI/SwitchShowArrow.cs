using UnityEngine;
using UnityEngine.UI;

public class SwitchShowArrow : MonoBehaviour
{
    [SerializeField]
    private GameObject showArrow;
    [SerializeField]
    private GameObject hideArrow;


    private void Start()
    {
        showArrow.SetActive(false);
        hideArrow.SetActive(true);
    }

    public void SwitchArrow()
    {
        showArrow.SetActive(!showArrow.activeSelf);
        hideArrow.SetActive(!hideArrow.activeSelf);
    }

    public void TransparentArrow()
    {
        var images = new Image[]
        {
            showArrow.GetComponent<Image>(),
            hideArrow.GetComponent<Image>()
        };
        var transParentImage = new TransParentImage();
        foreach (var image in images)
        {
            StartCoroutine(transParentImage.HideImage(image));
        }
    }
}
