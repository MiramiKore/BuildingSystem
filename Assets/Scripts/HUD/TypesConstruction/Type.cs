using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.TypesConstruction
{
    public class Type : MonoBehaviour
    {
        public Button button;
        public TypeBuilding type;
        
        private void Awake()
        {
            button = GetComponent<Button>();
        }
    }
}