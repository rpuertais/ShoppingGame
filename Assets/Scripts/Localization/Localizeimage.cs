using UnityEngine;
using UnityEngine.UI;

public class Localizeimage : MonoBehaviour
{
    public Language Language;

    [Header("Backgrounds")]
    [SerializeField] private Sprite englishBackground;
    [SerializeField] private Sprite catalanBackground;
    [SerializeField] private Sprite spanishBackground;

    private Image imageBackground;

    private void Start()
    {
        imageBackground = GetComponent<Image>();
    }
    /*
       private void Update()
       {
           if (Language == Language.English)
           {
               ChangeBackground(englishBackground);
           }
           else if (Language == Language.Catalan)
           {
               ChangeBackground(catalanBackground);
           }
           else if (Language == Language.Spanish)
           {
               ChangeBackground(spanishBackground);
           }
       }

       private void ChangeBackground(Sprite language)
       {
           imageBackground = language;
       }*/
}