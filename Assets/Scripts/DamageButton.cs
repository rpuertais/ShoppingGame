using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButton : MonoBehaviour
{
    public PlayerStats playerStats;
    public int damageAmount = 10;

    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(DoDamage);
    }

    private void OnDestroy()
    {
        btn.onClick.RemoveListener(DoDamage);
    }

    private void DoDamage()
    {
        if (playerStats == null) return;
        playerStats.Damage(damageAmount);
    }
}