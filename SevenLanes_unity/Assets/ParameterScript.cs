using UnityEngine;
using UnityEngine.UI;

// Parameterのキャンバスに付与
// 自機のスピードを表示・移動距離を表示・高度を表示する

public class ParameterScript : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public Text distanceText; // 距離を表示するText UI
    public Text altitudeText; // 高度を表示するText UI
    public Text speedText; // スピードを表示するText UI

    private Vector3 startingPosition; // 開始位置
    private float distance; // 移動距離
    private float altitude; // 高度
    private float speed; // 時速

    private CharaMove charaMove; // CharaMoveスクリプトへの参照

    // sin30度 (30度の正弦値) を定数として宣言
    private const float SIN30 = 0.536f;

    private void Start()
    {
        // **Nullチェック**
        if (player == null)
        {
            Debug.LogError("Playerオブジェクトが設定されていません！");
        }
        if (distanceText == null)
        {
            Debug.LogError("DistanceText が設定されていません！");
        }
        if (altitudeText == null)
        {
            Debug.LogError("AltitudeText が設定されていません！");
        }
        if (speedText == null)
        {
            Debug.LogError("SpeedText が設定されていません！");
        }

        // **CharaMoveスクリプトを取得**
        charaMove = player.GetComponent<CharaMove>();
        if (charaMove == null)
        {
            Debug.LogError("CharaMove スクリプトがプレイヤーにアタッチされていません！");
        }

        // 開始位置を保存
        startingPosition = player.position;
    }

    private void Update()
    {
        if (player != null)
        {
            // 移動距離を計算（Z軸での移動距離）
            distance = player.position.z - startingPosition.z;

            // 高度を計算（距離 * sin30）
            altitude = distance * SIN30;
            speed=(float)charaMove.forwardSpeed*3.6f;

            // Text UI にリアルタイムで反映
            distanceText.text = $"{((int)distance).ToString("D4")}";
            altitudeText.text = $"{((int)altitude).ToString("D4")}";

            // **CharaMove の forwardSpeed をリアルタイム表示**
            if (charaMove != null)
            {
                speedText.text =  $"{((int)speed).ToString("D4")}";
            }
        }
    }
}
