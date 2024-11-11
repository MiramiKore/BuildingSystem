using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using UnityEngine.Events;

namespace HUD.TypesConstruction
{
    public class SwitchingBuildingTypes : MonoBehaviour
    {
        public UnityEvent<TypeBuilding> switchBuildingType;
        
        [SerializeField] private List<Type> typesList;
        
        private void Start()
        {
            SetTypesListeners();
        }
        
        private void SetTypesListeners()
        {
            foreach (var type in typesList)
            {
                type.button.onClick.AddListener(() => SwitchType(type.type));
            }
        }

        private void SwitchType(TypeBuilding type)
        {
            switchBuildingType.Invoke(type);
        }
    }
}