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
    public int MAXEssenceKindCount = 7;

    private EssenceSEScript essenceSEScript;
    public GameObject sparkEffectPrefab; // Spark時のエフェクト
    public float rayDistance = 100f; // レイの長さ
    public LayerMask hitLayers; // ヒットさせたいレイヤー（任意）


    private int[] collectedEssence = new int[7]; // 7種類のアイテム、それぞれ最大4つまで
    public int RainbowArrowCount = 0;//虹の矢を数える
    public int EssenceKindCount = 6;//エッセンスの種類を数える
    


    [SerializeField]
    private TestTubeManager testTubeManager;
    [SerializeField]
    private RainbowArrowUIManager rainbowArrowUIManager;


    private void Awake()
    {
        GameObject seEssenceObject = GameObject.Find("SE_Essence");
        essenceSEScript = seEssenceObject.GetComponent<EssenceSEScript>();
    }

    private void OnTriggerEnter(Collider other)
    {


        for (int i = 0; i < MAXEssenceKindCount; i++)
        {
            if (other.CompareTag($"Essence{i}")) // タグでアイテムを識別
            {
                CollectItem(i);
                Debug.Log($"{EssenceKindCount}");
                essenceSEScript.EssenceGetSE(EssenceKindCount);//取得SE再生する
                Destroy(other.gameObject); // アイテムを取得後、消す
                break;
            }

        }
    }

    private void CheckEssence()
    {
        if (collectedEssence.All(count => count > 0) && RainbowArrowCount < MAX_RainbowArrow)
        {
            TransformItems();
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
        EssenceKindCount = 6;
        for (int k = 0; k < MAXEssenceKindCount; k++)//エッセンスの取得種類に合わせて音階を上げる
        {
            if (collectedEssence[k] == 0) EssenceKindCount--;
        }

        // 各アイテムを最低1つ以上持っているかチェック
        CheckEssence();

    }

    private void TransformItems()
    {
        RainbowArrowCount++;
        rainbowArrowUIManager.ShowRainbowArrow();
        for (int i = 0; i < MAXEssenceKindCount; i++)
        {
            collectedEssence[i]--;
            testTubeManager.RemoveEssenceFromTestTube(i);
        }
        ;
        Debug.Log("すべてのアイテムを最低1つずつ集めたので、新しいアイテムに変化！");
        // ここで新しいアイテムに変化する処理を書く
    }

    private void SparkEffect()
    {

        Vector3 origin = new Vector3(transform.position.x, 1.0f, transform.position.z);
        Vector3 direction = Vector3.forward;

        // RayをSceneビューで確認
        Debug.DrawRay(origin, direction * rayDistance, Color.red, 1.0f);

        if (Physics.Raycast(origin, direction, out RaycastHit hit, rayDistance, hitLayers))
        {
            if (hit.collider.CompareTag("Spark"))
            {
                // ヒット時の処理（Sparkエフェクト生成など）
                Instantiate(sparkEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Debug.Log("Sparkに命中！");
            }
        }
    }

    public void ReleaseRainbowArrow()
    {
        if (RainbowArrowCount > 0)
        {
            RainbowArrowCount--;

            // 各アイテムを最低1つ以上持っているかチェック

            SparkEffect();

            rainbowArrowUIManager.HideRainbowArrow();
            //Debug.Log($"現在の虹の矢の数は{RainbowArrowCount}");

            // 子オブジェクト"ArrowEffect"を探す
            Transform arrowEffectTransform = transform.Find("ArrowEffect");
            if (arrowEffectTransform != null)
            {
                Animator arrowEffectAnimator = arrowEffectTransform.GetComponent<Animator>();
                if (arrowEffectAnimator != null)
                {
                    arrowEffectAnimator.SetTrigger("isEffectPlay");
                    Debug.Log("ArrowEffectアニメーションのトリガーを起動");
                }
                else
                {
                    Debug.LogWarning("ArrowEffectにAnimatorコンポーネントが見つかりません");
                }
            }
            else
            {
                Debug.LogWarning("ArrowEffectが見つかりません");
            }

            if (canExpandLane)
            {
                LaneCreator.instance.ExpandLane();
                canExpandLane = false;
            }
            CheckEssence();

        }
    }

}
