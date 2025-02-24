using UnityEngine;

public class InksManager : MonoBehaviour
{
    private int inkIndex = 0;

    [SerializeField]
    private GameObject[] inksInTestTube;


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
}
