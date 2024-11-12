using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.Data
{
    public class CardData : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI text;

        public void SetImage(Sprite newIcon)
        {
            icon.sprite = newIcon;
        }

        public void SetText(string newText)
        {
            text.text = newText;
        }
    }
}