using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.ConstructionMode.TypesOfBuildings.Types
{
    public class Type : MonoBehaviour
    {
        [HideInInspector] public Button button;
        public TypeBuilding type;
        
        private void Awake()
        {
            button = GetComponent<Button>();
        }
    }
}