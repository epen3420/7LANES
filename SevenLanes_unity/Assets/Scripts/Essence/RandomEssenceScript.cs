using UnityEngine;

public class RandomEssenceScript : MonoBehaviour
{
    public GameObject[] itemPrefabs; // 7種類のアイテムプレハブ
    public float[] xPositions ; // アイテムのX座標候補
    public float yPos =1.13f;

    public float zDistanceThreshold = 50f; // 50m進むごとにアイテムを生成
   // public int itemsPerSegment = 3; // 1回の生成で出現するアイテム数

    private float lastZPosition = 0f; // 最後にアイテムを生成したZ位置
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
            // ランダムなアイテムを選択
            int itemIndex = Random.Range(0, itemPrefabs.Length);

            // ランダムなX座標を選択
            float xPos = xPositions[itemIndex];

            // プレイヤーの進行位置を基準にZ軸方向へランダム配置
            float zPos = player.position.z + Random.Range(0f, zDistanceThreshold)+50f;

            // アイテムを生成
            Vector3 spawnPosition = new Vector3(xPos, yPos, zPos);
            Instantiate(itemPrefabs[itemIndex], spawnPosition, Quaternion.identity);
      //  }
    }
}
