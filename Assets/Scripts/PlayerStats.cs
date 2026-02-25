/*using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Life")]
    public int maxLife = 100;
    public int currentLife = 100;

    private void Awake()
    {
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);
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
        if (currentLife > maxLife) currentLife = maxLife;
    }

    public float GetLifeNormalized()
    {
        if (maxLife <= 0) return 0f;
        return (float)currentLife / maxLife;
    }
}*/

using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxLife = 100;
    public int currentLife = 100;

    private void Awake()
    {
        if (currentLife < 0) currentLife = 0;
        if (currentLife > maxLife) currentLife = maxLife;
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
        if (currentLife > maxLife) currentLife = maxLife;
    }

    public bool IsFullLife()
    {
        return currentLife >= maxLife;
    }

    public float GetLifeNormalized()
    {
        if (maxLife <= 0) return 0f;
        return (float)currentLife / maxLife;
    }
}