using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButton : MonoBehaviour
{
    public PlayerStats PlayerStats;
    public int DamageAmount = 10;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(DoDamage);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(DoDamage);
    }

    private void DoDamage()
    {
        if (PlayerStats == null)
        {
            return;
        }
        PlayerStats.Damage(DamageAmount);
    }
}