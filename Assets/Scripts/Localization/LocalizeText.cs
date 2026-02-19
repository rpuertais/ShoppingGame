using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour
{
    public string TextKey;
    private TextMeshProUGUI textValue;

    void Start()
    {
        textValue = GetComponent<TextMeshProUGUI>();
        textValue.text = Localizer.GetText(TextKey);
    }

    private void OnEnable()
    {
        Localizer.OnLanguageChange += ChangeLanguage;
    }

    private void OnDisable()
    {
        Localizer.OnLanguageChange -= ChangeLanguage;
    }

    private void ChangeLanguage()
    {
        textValue.text = Localizer.GetText(TextKey);
    }
}
