using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int[] collectedItems = new int[7]; // 7種類のアイテム、それぞれ最大4つまで

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
