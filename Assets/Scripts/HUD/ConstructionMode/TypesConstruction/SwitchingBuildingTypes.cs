using System.Collections.Generic;
using HUD.ConstructionMode.TypesConstruction.Types;
using HUD.Data;
using UnityEngine;
using UnityEngine.Events;

namespace HUD.ConstructionMode.TypesConstruction
{
    public class SwitchingBuildingTypes : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<TypeBuilding> switchBuildingType;
        
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