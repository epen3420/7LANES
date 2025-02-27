using UnityEngine;

public class RandomEssenceScript : MonoBehaviour
{
    public GameObject[] itemPrefabs; // 7種類のアイテムプレハブ
    public float[] xPositions; // アイテムのX座標候補

    public float yPos = 0f;//エッセンスの高さ調節用関数

    public float zDistanceThreshold = 10f; // 50m進むごとにアイテムを生成

                                           // public int itemsPerSegment = 3; // 1回の生成で出現するアイテム数

    private float lastZPosition = 0f; // 最後にアイテムを生成したZ位置
    private int[] bias = new int[7];

    private Transform player; // プレイヤーのTransform

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // プレイヤーを取得
        lastZPosition = player.position.z; // 初期Z位置を記録
    }

    private void Update()
    {
        // プレイヤーが50m進んだらアイテムを生成
        if (player.position.z - lastZPosition >= zDistanceThreshold)
        {
            SpawnItems();
            lastZPosition = player.position.z; // 最後のZ位置を更新
        }
    }

    private void SpawnItems()
    {
        //    for (int i = 0; i < itemsPerSegment; i++)
        //     {

        int BiasCount = 0;//0でないエッセンスの種類数をカウントする 値1〜7. 7のとき全部のエッセンスが出された
        int lastMissingItem = -1; // まだ出現していないアイテムのインデックス

if(BiasCount==7){for(int i = 0; i < 7; i++)bias[i]--;}
        // 現在出現しているアイテムの数をカウントし、未出現のアイテムを記録
        for (int i = 0; i < 7; i++)
        {
            if (bias[i] > 0) BiasCount++;
            else lastMissingItem = i; // 最後に見つかった未出現のアイテムを記録
        }

        int itemIndex;
        if (BiasCount == 6 && lastMissingItem != -1)
        {
            // 6種類が出現済みの場合、まだ出ていない7種類目を強制生成
            itemIndex = lastMissingItem;
            
        }
        else
        {
            // 通常のランダム選択
            itemIndex = Random.Range(0, itemPrefabs.Length);
        }

        bias[itemIndex]++; // 選ばれたアイテムのカウントを増やす
        
                           // ランダムなX座標を選択
        float xPos = xPositions[itemIndex];

        // プレイヤーの進行位置+50mを基準にZ軸方向へランダム配置




        float zPos = player.position.z + Random.Range(0f, zDistanceThreshold) + 50f;

        // アイテムを生成
        Vector3 spawnPosition = new Vector3(xPos, yPos, zPos);
        Instantiate(itemPrefabs[itemIndex], spawnPosition, Quaternion.identity);
        //  }
    }
}