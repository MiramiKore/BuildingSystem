using Gameplay.BuildingSystem;
using UnityEngine;

namespace Gameplay
{
    public class GameBootstrap : MonoBehaviour
    {
        private DisplayingBuildingPlacement _displayingBuildingPlacement;
        private BuildingConstruction _buildingConstruction;
        private ConstructionPreview _constructionPreview;
        private BuildingManager _buildingManager;
        private GridManager _gridManager;
        private Grid _grid;

        private void Awake()
        {
            BuildingSystemInitialize();
        }

        private void BuildingSystemInitialize()
        {
            _displayingBuildingPlacement = FindAnyObjectByType<DisplayingBuildingPlacement>();
            _buildingManager = FindAnyObjectByType<BuildingManager>();
            _buildingConstruction = FindAnyObjectByType<BuildingConstruction>();
            _constructionPreview = FindAnyObjectByType<ConstructionPreview>();
            _gridManager = FindAnyObjectByType<GridManager>();
            _grid = FindAnyObjectByType<Grid>();
            
            if (_buildingManager == null || _buildingConstruction == null || _constructionPreview == null ||
                _gridManager == null || _grid == null ||
                _displayingBuildingPlacement == null) Debug.LogWarning("Missing BuildingSystem component");

            _buildingManager.Initialize();
            _constructionPreview.Initialize(_grid, _buildingManager);
            _gridManager.Initialize(_grid, _buildingConstruction, _constructionPreview);
            _buildingConstruction.Initialize(_buildingManager, _constructionPreview, _gridManager);
            _displayingBuildingPlacement.Initialize(_gridManager, _buildingManager);
        }
    }
}