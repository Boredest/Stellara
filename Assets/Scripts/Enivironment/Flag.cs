using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour, IInteractable
{
    private bool isLevelOver;
    private int diamondWinCount = 3;
    public void Interact()
    {
        if(UIManager.numOfDiamonds == diamondWinCount)
        {
            isLevelOver = true;
        }
        
        Debug.Log("Level complete");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
