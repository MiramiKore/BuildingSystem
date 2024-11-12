using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class ConstructionPreview : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<Vector3> previewPosition;
        
        [SerializeField] private GameObject buildingPreview;
        [SerializeField] private LayerMask groundLayer;

        private Camera _mainCamera;
        
        private Grid _grid;

        public void Initialize(BuildingSystem buildingSystem)
        {
            _mainCamera = Camera.main;
            _grid = FindAnyObjectByType<Grid>();
            
            buildingSystem.startOfBuilding.AddListener(StartPreview);
            buildingSystem.processOfBuilding.AddListener(MovePreview);
            buildingSystem.endOfConstruction.AddListener(StopPreview);
        }

        private void StartPreview(GameObject building)
        {
            SetPreviewParameters(building);
            
            buildingPreview.SetActive(true);
        }
        
        private void StopPreview(GameObject building)
        {
            buildingPreview.SetActive(false);
        }
        
        private void SetPreviewParameters(GameObject building)
        {
            buildingPreview.transform.localScale = building.transform.localScale;
            buildingPreview.GetComponent<MeshFilter>().sharedMesh = building.GetComponent<MeshFilter>().sharedMesh;
        }
        
        private void MovePreview(GameObject building)
        {
            var ray = _mainCamera.ScreenPointToRay(Pointer.current.position.value);
            
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, groundLayer))
            {
                var currentPlace = hit.point;

                var cellCenterGrid = _grid.GetCellCenterWorld(_grid.WorldToCell(currentPlace));
                
                buildingPreview.transform.position = new Vector3(cellCenterGrid.x, 0.5f, cellCenterGrid.z);
                
                previewPosition.Invoke(buildingPreview.transform.position);
            }
        }
    }
}