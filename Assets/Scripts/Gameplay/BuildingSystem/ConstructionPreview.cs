using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Gameplay.BuildingSystem
{
    public class ConstructionPreview : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<Vector3, GameObject> previewIsMoving; // Событие перемещения проекции
        
        // Проекция постройки и слой земли
        [SerializeField] private GameObject buildingPreview;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private GameObject gridShader;

        private Camera _mainCamera;
        
        private Grid _grid;

        public void Initialize(Grid grid, BuildingManager buildingManager)
        {
            _mainCamera = Camera.main;
            _grid = grid;
            
            buildingManager.startOfBuilding.AddListener(StartPreview);
            buildingManager.processOfBuilding.AddListener(MovePreview);
            buildingManager.endOfConstruction.AddListener(StopPreview);
        }

        // Начинает отображение проекции
        private void StartPreview(GameObject building)
        {
            SetPreviewParameters(building);
            
            buildingPreview.SetActive(true);
            gridShader.SetActive(true);
        }
        
        // Останавливаем отображение проекции
        private void StopPreview(GameObject building)
        {
            buildingPreview.SetActive(false);
            gridShader.SetActive(false);
        }
        
        // Меняем вид проекции на префаб постройки
        private void SetPreviewParameters(GameObject building)
        {
            buildingPreview.transform.localScale = building.transform.localScale;
            buildingPreview.GetComponent<MeshFilter>().sharedMesh = building.GetComponent<MeshFilter>().sharedMesh;
        }
        
        // Перемещаем проекцию постройки за указателем
        private void MovePreview(GameObject building)
        {
            var ray = _mainCamera.ScreenPointToRay(Pointer.current.position.value);
            
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, groundLayer))
            {
                var currentPlace = hit.point;

                // Находим цент ячейки по текущему положения проекции
                var cellCenterGrid = _grid.GetCellCenterWorld(_grid.WorldToCell(currentPlace));
                
                buildingPreview.transform.position = new Vector3(cellCenterGrid.x, 0.5f, cellCenterGrid.z);
                
                previewIsMoving.Invoke(buildingPreview.transform.position, building);
            }
        }
    }
}