using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PooledSound : MonoBehaviour, IPooledObject
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnObjectSpawn()
    {
        audioSource.Play();
    }
}
