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

    private int targetPlayerCoins;
    private int targetShopCoins;

    private void Start()
    {
        RefreshUI();
    }

    private void Update()
    {
        float speed = 10 * Time.deltaTime;

        if (targetPlayerCoins < PlayerCoins && targetShopCoins > ShopCoins)
        {
            PlayerCoins -= Mathf.CeilToInt(speed);
            ShopCoins += Mathf.CeilToInt(speed);
        }
        if (targetPlayerCoins > PlayerCoins && targetShopCoins < ShopCoins)
        {
            PlayerCoins += Mathf.CeilToInt(speed);
            ShopCoins -= Mathf.CeilToInt(speed);
        }

        RefreshUI();
    }

    public bool CanAfford(int amount)
    {
        return PlayerCoins >= amount;
    }

    public void Add(int amount)
    {
        if (amount <= 0) return;
        if (ShopCoins < amount) return;

        
        targetPlayerCoins = PlayerCoins + amount;
        targetShopCoins = ShopCoins - amount;
        RefreshUI();
    }

    public bool Spend(int amount)
    {
        if (amount <= 0) return true;
        if (PlayerCoins < amount) return false;
        
        targetPlayerCoins = PlayerCoins - amount;
        targetShopCoins = ShopCoins + amount;
        RefreshUI();
        return true;
    }

    public bool Sell(int amount)
    {
        if (ShopCoins < amount || ShopCoins == 0) return false;
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