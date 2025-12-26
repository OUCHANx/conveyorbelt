using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CoinManager : MonoBehaviour
{
    public static int coins = 0;
    [SerializeField] private TextMeshProUGUI coinText;
    private void Start()
    {
        coins = 0;
    }
    private void Update()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins.ToString();
        }
    }
    public static void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("コイン: " + coins);
    }
}
