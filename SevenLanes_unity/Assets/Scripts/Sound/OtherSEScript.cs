using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//カウンター更新時にSEを再生するスクリプト

public class OtherSEScript : MonoBehaviour
{
    public AudioClip LaneCountSound;//カウントが押されたときのSE　一回だけ鳴る
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartCountSE()
    {
        audioSource.PlayOneShot(LaneCountSound);
    }
}
