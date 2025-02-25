using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EssenceGetScript : MonoBehaviour
{
    public int MAX_Essence = 4;
    public int MAX_RainbowArrow = 3;
    public bool canExpandLane = false;

    private EssenceGetSoundScript essenceGetSoundScript;


    private int[] collectedEssence = new int[7]; // 7種類のアイテム、それぞれ最大4つまで
    public int RainbowArrowCount = 0;//虹の矢を数える
    public int EssenceKindCount=7;//エッセンスの種類を数える

    [SerializeField]
    private TestTubeManager testTubeManager;
    [SerializeField]
    private RainbowArrowUIManager rainbowArrowUIManager;

    private void Awake(){
        essenceGetSoundScript = GetComponent<EssenceGetSoundScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        EssenceKindCount=7;
        for (int i = 0; i < 7; i++)
        {
            if(collectedEssence[i]==0)EssenceKindCount--;
        }

        for (int i = 0; i < 7; i++)
        {
            if (other.CompareTag($"Essence{i}")) // タグでアイテムを識別
            {
                CollectItem(i);
                essenceGetSoundScript.EssenceGetSE(i);
                Destroy(other.gameObject); // アイテムを取得後、消す
                break;
            }

        }
    }

    private void CollectItem(int itemIndex)
    {
        if (collectedEssence[itemIndex] < MAX_Essence)
        {
            collectedEssence[itemIndex]++;
            testTubeManager.AddEssenceToTestTube(itemIndex);
            Debug.Log($"アイテム{itemIndex}を取得。現在の個数: {collectedEssence[itemIndex]}");
        }
        else
        {
            Debug.Log($"アイテム{itemIndex}はすでに最大数を持っています。");
        }

        // 各アイテムを最低1つ以上持っているかチェック
        if (collectedEssence.All(count => count > 0) && RainbowArrowCount < MAX_RainbowArrow)
        {
            TransformItems();
        }
    }

    private void TransformItems()
    {
        RainbowArrowCount++;
        rainbowArrowUIManager.ShowRainbowArrow();
        for (int i = 0; i < 7; i++)
        {
            collectedEssence[i]--;
            testTubeManager.RemoveEssenceFromTestTube(i);
        }
        ;
        Debug.Log("すべてのアイテムを最低1つずつ集めたので、新しいアイテムに変化！");
        // ここで新しいアイテムに変化する処理を書く
    }

    public void ReleaseRainbowArrow()
    {
        if (RainbowArrowCount > 0)
        {
            RainbowArrowCount--;
            rainbowArrowUIManager.HideRainbowArrow();
            Debug.Log($"現在の虹の矢の数は{RainbowArrowCount}");

            if (canExpandLane)
            {
                LaneCreator.instance.ExpandLane();
                canExpandLane = false;
            }
        }
    }
}
