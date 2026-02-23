using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBarUI : MonoBehaviour
{
    public PlayerStats playerStats;
    private Image barImage;

    private void Awake()
    {
        barImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (playerStats == null) return;

        barImage.fillAmount = playerStats.GetLifeNormalized();
    }
}