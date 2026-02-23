using TMPro;
using UnityEngine;

public class CoinsWallet : MonoBehaviour
{
    [Header("PlayerWallet")]
    public int PlayerCoins = 100;
    public TextMeshProUGUI PlayerCoinsText;
    [Header("ShopWallet")]
    public int ShopCoins = 100;
    public TextMeshProUGUI ShopCoinsText;

    private void Start()
    {
        RefreshUI();
    }

    public bool CanAfford(int amount)
    {
        return PlayerCoins >= amount;
    }

    public void Add(int amount)
    {
        if (amount <= 0) return;
        PlayerCoins += amount;
        ShopCoins -= amount;
        RefreshUI();
    }

    public bool Spend(int amount)
    {
        if (amount <= 0) return true;
        if (PlayerCoins < amount) return false;

        PlayerCoins -= amount;
        ShopCoins += amount;
        RefreshUI();
        return true;
    }

    public void RefreshUI()
    {
        if (PlayerCoinsText != null && ShopCoinsText != null)
        {
            PlayerCoinsText.text = PlayerCoins.ToString();
            ShopCoinsText.text = ShopCoins.ToString();
        }
    }
}