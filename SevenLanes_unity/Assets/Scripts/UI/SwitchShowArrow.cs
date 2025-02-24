using UnityEngine;

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
}
