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
            FindAnyObjectByType<CardsOfBuildings>().cardIsClick.AddListener(StartBuilding);
            FindAnyObjectByType<CardsOfBuildings>().cardIsHeld.AddListener(StartBuildingProcess);
        }

        private void StartBuildingProcess(bool buttonStart, GameObject prefab)
        {
            StartCoroutine(BuildingProcess(buttonStart, prefab));
        }

        private void StartBuilding(GameObject prefab)
        {
            Debug.Log("StartBuilding");
            startOfBuilding.Invoke(prefab);
        }

        private IEnumerator BuildingProcess(bool buttonHold, GameObject prefab)
        {
            if (buttonHold)
            {
                Debug.Log("ProcessBuilding");
                processOfBuilding.Invoke(prefab);
            }
            else
            {
                Debug.Log("EndBuilding");
                endOfConstruction.Invoke(prefab);
            }
            
            yield break;
        }
    }
}