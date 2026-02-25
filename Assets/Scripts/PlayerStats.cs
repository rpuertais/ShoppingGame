using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int MaxLife = 100;
    public int currentLife = 100;

    private void Awake()
    {
        if (currentLife < 0) currentLife = 0;
        if (currentLife > MaxLife) currentLife = MaxLife;
    }

    private void Update()
    {
        if (currentLife <= 0) SceneManager.LoadScene(2); ;
    }

    public void Damage(int amount)
    {
        if (amount <= 0) return;

        currentLife -= amount;
        if (currentLife < 0) currentLife = 0;
    }

    public void Heal(int amount)
    {
        if (amount <= 0) return;

        currentLife += amount;
        if (currentLife > MaxLife) currentLife = MaxLife;
    }

    public bool IsFullLife()
    {
        return currentLife >= MaxLife;
    }

    public float GetLifeNormalized()
    {
        if (MaxLife <= 0) return 0f;
        return (float)currentLife / MaxLife;
    }
}