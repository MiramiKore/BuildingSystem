using System.Collections.Generic;
using Gameplay;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Type = HUD.ConstructionMode.TypesOfBuildings.Types.Type;

namespace HUD.ConstructionMode.TypesOfBuildings
{
    public class SwitchingBuildingTypes : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<TypeBuilding> switchBuildingType; // Тип строительных объектов сменился

        [SerializeField] private List<Type> typesList; // Список хранящий типы строиельных объектов

        [SerializeField] private Color customColor; // Цвет активного типа строительных объектов

        private void OnEnable()
        {
            SetTypesListeners();
        }

        private void OnDisable()
        {
            RemoveTypesListeners();
        }

        // Установка слушателей на кнопки типов
        private void SetTypesListeners()
        {
            if (typesList.Count == 0) return;
            
            foreach (var type in typesList)
            {
                type.button.onClick.AddListener(() => SwitchType(type));
            }
            
            SetButtonColor(typesList[0]);
        }

        // Удаление слушателей с кнопок типов
        private void RemoveTypesListeners()
        {
            if (typesList.Count == 0) return;
            
            foreach (var type in typesList)
            {
                type.button.onClick.RemoveAllListeners();
            }
        }

        // Смена типа стрительных объектов
        private void SwitchType(Type type)
        {
            SetButtonColor(type);
            
            switchBuildingType.Invoke(type.type);
        }

        // Устанавливаем цвет активной вкладки
        private void SetButtonColor(Type type)
        {
            foreach (var button in typesList)
            {
                button.GetComponent<Image>().color = Color.white;
            }
            
            var buttonColor = type.button.GetComponent<Image>();
            buttonColor.color = customColor;
        }
    }
}