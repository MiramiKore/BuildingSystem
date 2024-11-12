using Gameplay.BuildingSystem.Interfaces;
using UnityEngine;

namespace Gameplay.BuildingSystem
{
    public class DisplayingBuildingPlacement : MonoBehaviour
    {
        // Цвета для индикации на проекции
        [SerializeField] private Color freeSpaceColor;
        [SerializeField] private Color occupiedSpaceColor;

        [SerializeField] private Material previewMaterial;

        private IPlaceable _placeable;

        public void Initialize(GridManager gridManager, BuildingManager buildingManager)
        {
            _placeable = gridManager;
            buildingManager.processOfBuilding.AddListener(CheckPlacing);
        }

        // Изменяем цвет проекции в зависимости от того, возможно ли ее разместить
        private void CheckPlacing(GameObject building)
        {
            previewMaterial.color = _placeable.CanPlace ? freeSpaceColor : occupiedSpaceColor;
        }
    }
}