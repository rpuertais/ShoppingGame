using UnityEngine;
using UnityEngine.UI;

public class Localizeimage : MonoBehaviour
{
    public LanguageButton LanguageButton;

    [Header("Backgrounds")]
    [SerializeField] private Sprite englishBackground;
    [SerializeField] private Sprite catalanBackground;
    [SerializeField] private Sprite spanishBackground;

    private Image imageBackground;

    void Start()
    {
        imageBackground = GetComponent<Image>();
    }
   
    void Update()
    {
        if (LanguageButton.Language == Language.English)
        {
            imageBackground.sprite = englishBackground;
        }
        else if (LanguageButton.Language == Language.Catalan)
        {
            imageBackground.sprite = catalanBackground;
        }
        else if (LanguageButton.Language == Language.Spanish)
        {
            imageBackground.sprite = spanishBackground;
        }
    }
}