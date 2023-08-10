using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Diamond : MonoBehaviour, ICollectible
{
    public static event Action OnDiamondCollected;
    public void Collect()
    {
        Debug.Log("Diamond Collected");
        Destroy(gameObject);
        OnDiamondCollected?.Invoke();
    }
}
