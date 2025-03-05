using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//エッセンスの取得SEのみを再生するスクリプト
public class EssenceSEScript : MonoBehaviour
{
    public AudioClip[] GetSound;//エッセンス取得時のSE
    AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void EssenceGetSE(int index)
    {
        audioSource.PlayOneShot(GetSound[index]);
    }
}
