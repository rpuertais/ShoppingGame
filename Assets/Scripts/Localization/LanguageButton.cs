using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour, IPointerClickHandler
{
    public Language Language;

    private TextMeshProUGUI localizedText;

    public void Start()
    {
        localizedText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        localizedText.text = Language.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Language += 1;
        if (Language > Language.Spanish) Language = Language.English;

        Localizer.SetLanguage(Language);

        localizedText.text = Language.ToString();
    }
}