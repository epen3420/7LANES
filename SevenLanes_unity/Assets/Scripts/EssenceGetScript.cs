using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int[] collectedItems = new int[7]; // 7種類のアイテム、それぞれ最大4つまで
    public Text EssenceCountText;


    void Update()
    {
        EssenceCountText.text = string.Format(@"
        赤いエッセンスの数 {0} 個
        オレンジエッセンスの数 {1} 個
        黄色いエッセンスの数 {2} 個
        緑エッセンスの数 {3} 個
        水色エッセンスの数 {4} 個
        青エッセンスの数 {5} 個
        紫エッセンスの数 {6} 個"
        ,collectedItems[0],collectedItems[1],collectedItems[2],collectedItems[3],collectedItems[4],collectedItems[5],collectedItems[6]);

        
    }

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
        if (collectedItems[itemIndex] < 4)
        {
            collectedItems[itemIndex]++;
            Debug.Log($"アイテム{itemIndex}を取得。現在の個数: {collectedItems[itemIndex]}");
        }
        else
        {
            Debug.Log($"アイテム{itemIndex}はすでに最大数を持っています。");
        }

        // 各アイテムを最低1つ以上持っているかチェック
        if (collectedItems.All(count => count > 0))
        {
            TransformItems();
        }
    }

    private void TransformItems()
    {
        Debug.Log("すべてのアイテムを最低1つずつ集めたので、新しいアイテムに変化！");
        // ここで新しいアイテムに変化する処理を書く
    }
}
