using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int MaxLife = 100;
    public int CurrentLife = 100;

    private void Awake()
    {
        if (CurrentLife < 0)
        {
            CurrentLife = 0;
        }
        if (CurrentLife > MaxLife)
        {
            CurrentLife = MaxLife;
        }
    }

    private void Update()
    {
        if (CurrentLife <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void Damage(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        CurrentLife -= amount;
        if (CurrentLife < 0)
        {
            CurrentLife = 0;
        }
    }

    public void Heal(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        CurrentLife += amount;
        if (CurrentLife > MaxLife)
        {
            CurrentLife = MaxLife;
        }
    }

    public bool IsFullLife()
    {
        return CurrentLife >= MaxLife;
    }

    public float GetLife()
    {
        if (MaxLife <= 0)
        {
            return 0f;
        }
        return (float)CurrentLife / MaxLife;
    }
}