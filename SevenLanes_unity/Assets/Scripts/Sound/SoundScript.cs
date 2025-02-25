using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip[] GetSound;//エッセンス取得時のSE
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

public void NGDrawBowSE(){
    audioSource.PlayOneShot(NGDrawSound);
}
    public void ShootingArrowSE()
    {
        audioSource.PlayOneShot(ShootingSound);
    }
}
