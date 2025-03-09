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

    private CharaMove charaMove; // CharaMoveスクリプトへの参照

    private const float SIN30 = 0.536f; // sin30度の値
    private float BGChangeInterval = 300f;//BGChangeを呼び出す間隔
    private float nextDistanceThreshold; // 次にBGChangeを呼び出す閾値
    private int backgroundIndex = 1; // BGChangeのインデックス


    public BGChangeScript bgChangeScript; // BGChangeScriptへの参照

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
        if (bgChangeScript == null)
        {
            Debug.LogError("BGChangeScript が設定されていません！");
        }

        // **CharaMoveスクリプトを取得**
        charaMove = player.GetComponent<CharaMove>();
        if (charaMove == null)
        {
            Debug.LogError("CharaMove スクリプトがプレイヤーにアタッチされていません！");
        }

        // 開始位置を保存
        startingPosition = player.position;
        nextDistanceThreshold=BGChangeInterval;
    }

    private void Update()
    {
        if (player != null)
        {
            // 移動距離を計算（Z軸での移動距離）
            distance = player.position.z - startingPosition.z;

            // 高度を計算（距離 * sin30）
            altitude = distance * SIN30;

            // Text UI にリアルタイムで反映
            distanceText.text = $"Distance: {distance:F2} m";
            altitudeText.text = $"Altitude: {altitude:F2} m";

            // **CharaMove の forwardSpeed をリアルタイム表示**
            if (charaMove != null)
            {
                speedText.text = $"Speed: {charaMove.forwardSpeed:F2} m/s";
            }

            // **10m 進むごとに BGChange を呼び出す**
            if (distance >= nextDistanceThreshold)
            {
                nextDistanceThreshold += BGChangeInterval; // 次の閾値を10m増やす
                ChangeBackground();
            }
        }
    }

    private void ChangeBackground()
    {
        // インデックスが背景配列のサイズを超えないようにループ
        if (bgChangeScript != null)
        {
            if(backgroundIndex<5){
            Debug.Log($"BGChange を実行: Index = {backgroundIndex}");
            bgChangeScript.ChangeBG(backgroundIndex);
            }
            backgroundIndex++;
        }
    }
}
