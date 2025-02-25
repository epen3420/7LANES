using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip[] GetSound;//エッセンス取得時のSE
    public AudioClip ShootingSound;//矢を放つときのSE　矢が飛ぶSEではない
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void EssenceGetSE(int index)
    {
        audioSource.PlayOneShot(GetSound[index]);
    }

    public void ShootingArrowSE()
    {
        audioSource.PlayOneShot(ShootingSound);
    }
}
