using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceGetSoundScript : MonoBehaviour
{
    public AudioClip[] GetSound;
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
