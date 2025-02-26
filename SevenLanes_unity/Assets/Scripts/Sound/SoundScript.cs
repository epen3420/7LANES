using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip[] GetSound;//エッセンス取得時のSE
    public AudioClip StartDrawingSound;//弓を引き始めるときのSE　一回だけ鳴る
    public AudioClip KeepDrawingSound;//弓を引き続けるSE　ループ
    public AudioClip ShootingSound;//矢を放つときのSE　矢が飛ぶSEではない
    public AudioClip NGDrawSound;//矢がない状態で弓を引いたときの音

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
        public void KeepDrawingSE()
    {
        audioSource.PlayOneShot(KeepDrawingSound);
    }
    public void NGDrawBowSE()
    {
        audioSource.PlayOneShot(NGDrawSound);
    }
    public void ShootingArrowSE()
    {
        audioSource.PlayOneShot(ShootingSound);
    }
}
