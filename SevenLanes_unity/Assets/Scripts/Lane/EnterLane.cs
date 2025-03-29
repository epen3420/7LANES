using UnityEngine;

public class EnterLane : MonoBehaviour
{
    private Animator laneCounterAnim;
    private OtherSEScript otherSEScript;

    private void Awake()
    {
        GameObject laneCounter = GameObject.Find("LaneCounter");
        laneCounterAnim = laneCounter.GetComponent<Animator>();

        GameObject otherSEObject = GameObject.Find("SE_Others");
        otherSEScript= otherSEObject.GetComponent<OtherSEScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        // LaneCounter の Animator のトリガーをオンにする
        laneCounterAnim.SetTrigger("IsCount");
        //SE再生する
        otherSEScript.StartCountSE();
Debug.Log("SE再生");


        var laneCount = LaneCreator.instance.LaneCount;
        other.GetComponent<CharaMove>().forwardSpeed =10.0f * (Mathf.Pow(1.1f, laneCount) + 0.3f * laneCount);
        LaneCreator.instance.CountLane();
    }
}
