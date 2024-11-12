using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.ConstructionMode
{
    public class CardData : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI text;
        
        // Установка иконки карточки
        public void SetImage(Sprite newIcon)
        {
            icon.sprite = newIcon;
        }

        // Установка текста на карточке
        public void SetText(string newText)
        {
            text.text = newText;
        }
    }
}