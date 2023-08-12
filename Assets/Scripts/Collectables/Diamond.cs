using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Diamond : MonoBehaviour, ICollectible
{
    public static event Action OnDiamondCollected;
    [SerializeField] AudioClip diamondCollect;
    public void Collect()
    {
        Debug.Log("Diamond Collected");
        AudioManager.Instance.PlaySound(diamondCollect);   
        OnDiamondCollected?.Invoke();
        Destroy(gameObject);
    }
}
