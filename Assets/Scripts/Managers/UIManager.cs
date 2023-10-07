using UnityEngine;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{

    public static int numOfDiamonds = 0;
    private int numOfCoins = 0;

    [SerializeField] private Text coinText;
    [SerializeField] private Image[] diamonds;

    private void Start()
    {
        coinText.text = numOfCoins.ToString();
        numOfDiamonds = 0;
    }
    private void OnEnable()
    {
        Diamond.OnDiamondCollected += UpdateDiamondSprites;
        Coin.OnCoinCollected += UpdateCoins;
    }

    private void OnDisable()
    {
        Diamond.OnDiamondCollected -= UpdateDiamondSprites;
        Coin.OnCoinCollected -= UpdateCoins;
    }

    private void UpdateDiamondSprites()
    {
        
        if (numOfDiamonds < diamonds.Length)
        {
            diamonds[numOfDiamonds].color = Color.white;
            numOfDiamonds++;
            

        }

    }

    private void UpdateCoins()
    {
        numOfCoins++;
        coinText.text = numOfCoins.ToString();
        
    }

}
