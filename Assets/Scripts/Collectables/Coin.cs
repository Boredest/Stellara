using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    public static event Action OnCoinCollected;
    [SerializeField] AudioClip coinCollect;

    public void Collect()
    {
        AudioManager.Instance.PlaySound(coinCollect);
        OnCoinCollected?.Invoke();
        Destroy(gameObject);
    }
}
