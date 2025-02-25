using System.Collections;
using UnityEngine;

public class GameOverPanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;
    [SerializeField]
    private GameObject panelObj;


    private void Start()
    {
        panelObj.SetActive(false);
        StartCoroutine(WaitUntilDestroy());
    }

    private IEnumerator WaitUntilDestroy()
    {
        while (targetObj != null)
        {
            yield return null;
        }
        panelObj.SetActive(true);
    }
}
