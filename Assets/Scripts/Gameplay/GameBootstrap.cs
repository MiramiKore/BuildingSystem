using UnityEngine;

namespace Gameplay
{
    public class GameBootstrap : MonoBehaviour
    {
        private BuildingConstruction _buildingConstruction;
        private ConstructionPreview _constructionPreview;
        private BuildingSystem _buildingSystem;

        private void Awake()
        {
            _buildingSystem = FindAnyObjectByType<BuildingSystem>();
            _buildingConstruction = FindAnyObjectByType<BuildingConstruction>();
            _constructionPreview = FindAnyObjectByType<ConstructionPreview>();
            
            _buildingSystem.Initialize();
            _constructionPreview.Initialize(_buildingSystem);
            _buildingConstruction.Initialize(_buildingSystem, _constructionPreview);
        }
    }
}