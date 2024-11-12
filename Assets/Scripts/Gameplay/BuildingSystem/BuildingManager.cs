using System.Collections;
using HUD.ConstructionMode;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.BuildingSystem
{
    public class BuildingManager : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<GameObject> startOfBuilding;
        [HideInInspector] public UnityEvent<GameObject> processOfBuilding;
        [HideInInspector] public UnityEvent<GameObject> endOfConstruction;

        public void Initialize()
        {
            FindAnyObjectByType<CardParameters>().cardIsClick.AddListener(StartBuilding);
            FindAnyObjectByType<CardParameters>().cardIsHeld.AddListener(StartBuildingProcess);
        }

        // Запускаем процесс строительства
        private void StartBuildingProcess(bool buttonHold, GameObject prefab)
        {
            StartCoroutine(BuildingProcess(buttonHold, prefab));
        }

        // Начало строительства
        private void StartBuilding(GameObject prefab)
        {
            startOfBuilding.Invoke(prefab);
        }

        // Процесс строительства
        private IEnumerator BuildingProcess(bool buttonHold, GameObject prefab)
        {
            if (buttonHold)
            {
                processOfBuilding.Invoke(prefab);
            }
            else
            {
                endOfConstruction.Invoke(prefab);
            }
            
            yield break;
        }
    }
}