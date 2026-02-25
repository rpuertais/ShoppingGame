using UnityEngine;
using TMPro;

public class PlayerLifeText : MonoBehaviour
{
    public PlayerStats PlayerStats;
    private TextMeshProUGUI lifeText;

    private void Awake()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        lifeText.text = "" + PlayerStats.CurrentLife;
    }
}