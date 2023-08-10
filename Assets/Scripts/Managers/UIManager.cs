using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    private int numOfDiamonds = 0;
    
    private int numOfCoins = 0;
   

    [SerializeField] private Image[] diamonds;
   



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Diamond.OnDiamondCollected += UpdateDiamondSprites;
    }

    private void OnDisable()
    {
        Diamond.OnDiamondCollected -= UpdateDiamondSprites;
    }

    private void UpdateDiamondSprites()
    {
       if (numOfDiamonds < diamonds.Length)
      {
            diamonds[numOfDiamonds].color = Color.white;
            numOfDiamonds++;
            Debug.Log(numOfDiamonds);

        }
      
    }

}
