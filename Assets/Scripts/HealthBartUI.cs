using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBarUI : MonoBehaviour
{
    public PlayerStats PlayerStats;
    private Image barImage;

    private void Awake()
    {
        barImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (PlayerStats == null)
        {
            return;
        }
        barImage.fillAmount = (float)PlayerStats.GetLife();
    }
}