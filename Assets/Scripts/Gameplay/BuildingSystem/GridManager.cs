using System.Collections.Generic;
using Gameplay.BuildingSystem.Interfaces;
using UnityEngine;

namespace Gameplay.BuildingSystem
{
    public class GridManager : MonoBehaviour, IPlaceable
    {
        // Храним занятые ячейки и объект который их занимает
        private readonly Dictionary<Vector2Int, GameObject> _occupiedCells = new(); 

        private Grid _grid;

        public bool CanPlace { get; private set; }

        public void Initialize(Grid grid, BuildingConstruction buildingConstruction, ConstructionPreview constructionPreview)
        {
            _grid = grid;
            
            buildingConstruction.buildingComplete.AddListener(PlaceOnGrid);
            constructionPreview.previewIsMoving.AddListener(CanPlaceOnGrid);
        }
        
        // Размещаем объект на сетке
        private void PlaceOnGrid(GameObject building)
        {
            var buildingData = building.GetComponent<BuildingData>();
            
            foreach (var cellPosition in GetOccupiedCells(building.transform.position, buildingData))
            {
                _occupiedCells[cellPosition] = buildingData.gameObject;
            }
        }

        // Проверям свободны ли ячейки для объекта нужного размера
        private void CanPlaceOnGrid(Vector3 prefabPosition, GameObject building)
        {
            var buildingData = building.GetComponent<BuildingData>();
            
            foreach (var cell in GetOccupiedCells(prefabPosition, buildingData))
            {
                if (_occupiedCells.ContainsKey(cell))
                {
                    CanPlace = false;
                    return;
                }
            }
            
            CanPlace = true;
        }
        
        // Получаем все ячейки занимаемые объектом вокруг базовой ячейки
        private IEnumerable<Vector2Int> GetOccupiedCells(Vector3 buildingPosition, BuildingData data)
        {
            var baseCellPosition = _grid.WorldToCell(buildingPosition);

            // Вычисляем половину размера постройки для коректного заполения вокруг базовой ячейки
            var halfWidth = Mathf.FloorToInt(data.size.x / 2f);
            var halfHeight = Mathf.FloorToInt(data.size.y / 2f);

            // Вычисляем кол-во требуемых ячеек в зависимости от размера постройки
            for (var x = -halfWidth; x <= halfWidth; x++)
            {
                for (var z = -halfHeight; z <= halfHeight; z++)
                {
                    yield return new Vector2Int(baseCellPosition.x + x, baseCellPosition.y + z);
                }
            }
        }
    }
}