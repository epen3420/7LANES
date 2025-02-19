using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EssenceGetScript : MonoBehaviour
{
    public int MAX_Essence = 4;
    public int MAX_RainbowArrow = 3;



    private int[] collectedEssence = new int[7]; // 7種類のアイテム、それぞれ最大4つまで
    private int RainbowArrowCount = 0;//虹の矢を数える
    public Text EssenceCountText;//取得したエッセンスの色と個数を確認するためのテキスト


    /* void Update()
    {
        EssenceCountText.text = string.Format(@"
        赤いエッセンスの数 {0} 個
        オレンジエッセンスの数 {1} 個
        黄色いエッセンスの数 {2} 個
        緑エッセンスの数 {3} 個
        水色エッセンスの数 {4} 個
        青エッセンスの数 {5} 個
        紫エッセンスの数 {6} 個

        虹の矢の数{7}個"
        ,collectedEssence[0],collectedEssence[1],collectedEssence[2],collectedEssence[3],collectedEssence[4],collectedEssence[5],collectedEssence[6],RainbowArrowCount);


    } */

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < 7; i++)
        {
            if (other.CompareTag($"Essence{i}")) // タグでアイテムを識別
            {
                CollectItem(i);
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
        for (int i = 0; i < 7; i++) collectedEssence[i]--;
        Debug.Log("すべてのアイテムを最低1つずつ集めたので、新しいアイテムに変化！");
        // ここで新しいアイテムに変化する処理を書く
    }
}
