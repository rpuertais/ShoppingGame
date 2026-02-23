using TMPro;
using UnityEngine;

public class CoinsWallet : MonoBehaviour
{
    public int coins = 100;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        RefreshUI();
    }

    public bool CanAfford(int amount)
    {
        return coins >= amount;
    }

    public void Add(int amount)
    {
        if (amount <= 0) return;
        coins += amount;
        RefreshUI();
    }

    public bool Spend(int amount)
    {
        if (amount <= 0) return true;
        if (coins < amount) return false;

        coins -= amount;
        RefreshUI();
        return true;
    }

    public void RefreshUI()
    {
        if (coinsText != null)
            coinsText.text = coins.ToString();
    }
}