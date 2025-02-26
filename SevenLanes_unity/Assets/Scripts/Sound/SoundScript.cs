using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip[] GetSound;//エッセンス取得時のSE
    public AudioClip StartDrawingSound;//弓を引き始めるときのSE　一回だけ鳴る

    public AudioClip ShootingSound;//矢を放つときのSE　矢が飛ぶSEではない
    public AudioClip NGDrawSound;//矢がない状態で弓を引いたときの音

     public AudioClip KeepDrawingSound;//弓を引き続けるSE　ループ
    public float loopStart =0.779f; // ループ開始時間（秒）
    public float loopEnd = 1.4998f;   // ループ終了時間（秒）
    private bool isLooping = false;

    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void EssenceGetSE(int index)
    {
        audioSource.PlayOneShot(GetSound[index]);
    }
    public void StartDrawingSE()
    {
        audioSource.PlayOneShot(StartDrawingSound);
    }

    public void NGDrawBowSE()
    {
        audioSource.PlayOneShot(NGDrawSound);
    }
    public void ShootingArrowSE()
    {
        audioSource.PlayOneShot(ShootingSound);
    }

public void KeepDrawingSE()
    {
        if (!isLooping)
        {
            isLooping = true;
            audioSource.clip = KeepDrawingSound;
            audioSource.Play();
            audioSource.time = loopStart; // イントロ部分をスキップしてループ開始位置に設定

            // ループ監視を開始
            StartCoroutine(LoopCheck());
        }
    }

    private IEnumerator LoopCheck()
    {
        while (isLooping)
        {
            yield return null; // 毎フレーム待機

            if (audioSource.time >= loopEnd)
            {
                audioSource.time = loopStart; // ループ開始地点に戻す
            }
        }
    }

    public void StopKeepDrawingSE()
    {
        isLooping = false;
        audioSource.Stop(); // ループを停止
        StopCoroutine(LoopCheck());
    }
}
