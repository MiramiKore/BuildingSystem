using UnityEngine;

namespace Gameplay
{
    public class BuildingConstruction : MonoBehaviour
    {
        [SerializeField] private Transform locationOnHierarchy;

        private Vector3 _previewPosition;

        public void Initialize(BuildingSystem buildingSystem, ConstructionPreview constructionPreview)
        {
            buildingSystem.endOfConstruction.AddListener(Build);
            constructionPreview.previewPosition.AddListener((pos) => _previewPosition = pos);
        }

        private void Build(GameObject prefab)
        {
            var building = Instantiate(prefab, locationOnHierarchy);
            building.transform.position = _previewPosition;
        }
    }
}