using Gameplay.BuildingSystem.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.BuildingSystem
{
    public class BuildingConstruction : MonoBehaviour
    {
        [SerializeField] private Transform locationOnHierarchy;

        [HideInInspector] public UnityEvent<GameObject> buildingComplete;

        private Vector3 _creationPosition;

        private IPlaceable _gridManager;

        public void Initialize(BuildingManager buildingManager, ConstructionPreview constructionPreview, GridManager gridManager)
        {
            _gridManager = gridManager;
            
            buildingManager.endOfConstruction.AddListener(Build);
            constructionPreview.previewIsMoving.AddListener((pos, _) => _creationPosition = pos);
        }

        // Строим здание
        private void Build(GameObject prefab)
        {
            if (_gridManager.CanPlace)
            {
                var building = Instantiate(prefab, locationOnHierarchy);
                building.transform.position = _creationPosition;
            
                buildingComplete.Invoke(building);
            }
            else
            {
                Debug.Log("Can't build");
            }
        }
    }
}