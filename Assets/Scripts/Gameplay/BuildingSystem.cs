using System.Collections;
using HUD.ConstructionMode;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class BuildingSystem : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<GameObject> startOfBuilding;
        [HideInInspector] public UnityEvent<GameObject> processOfBuilding;
        [HideInInspector] public UnityEvent<GameObject> endOfConstruction;

        public void Initialize()
        {
            FindAnyObjectByType<CardParameters>().cardIsClick.AddListener(StartBuilding);
            FindAnyObjectByType<CardParameters>().cardIsHeld.AddListener(StartBuildingProcess);
        }

        private void StartBuildingProcess(bool buttonStart, GameObject prefab)
        {
            StartCoroutine(BuildingProcess(buttonStart, prefab));
        }

        private void StartBuilding(GameObject prefab)
        {
            startOfBuilding.Invoke(prefab);
        }

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