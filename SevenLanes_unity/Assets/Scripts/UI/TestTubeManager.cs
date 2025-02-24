using UnityEngine;

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
}
