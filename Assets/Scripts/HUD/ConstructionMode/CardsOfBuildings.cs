using System.Collections.Generic;
using HUD.ConstructionMode.TypesConstruction;
using HUD.Data;
using HUD.GameModes;
using HUD.GameModes.Modes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace HUD.ConstructionMode
{
    public class CardsOfBuildings : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<bool, GameObject> cardIsHeld;
        [HideInInspector] public UnityEvent<GameObject> cardIsClick;

        [SerializeField] private GameObject buildingCardPrefab;
        [SerializeField] private Transform locationInHierarchy;

        public List<GameObject> cardsList;

        private BuildingRegister _buildingRegister;

        public void Initialize(SwitchingModsUI switchingModsUI, SwitchingBuildingTypes switchingBuildingTypes,
            BuildingRegister buildingRegister)
        {
            switchingModsUI.gameModeSwitch.AddListener(CheckOfCards);
            switchingBuildingTypes.switchBuildingType.AddListener(CreationOfCards);
            
            _buildingRegister = buildingRegister;
        }

        private void CheckOfCards(BaseGameMode gameMode)
        {
            if (gameMode.GetModeType() == GameModeType.Construction)
            {
                CreationOfCards(TypeBuilding.Base);
            }
            else
            {
                DestructionOfCards();
            }
        }

        public void CreationOfCards(TypeBuilding type)
        {
            DestructionOfCards();

            foreach (var buildingData in _buildingRegister.buildingsData)
            {
                if (buildingData.type == type)
                {
                    var buildingCard = Instantiate(buildingCardPrefab, locationInHierarchy);

                    SetCardInfo(buildingCard, buildingData);

                    SetTriggersListeners(buildingCard, buildingData);

                    cardsList.Add(buildingCard);
                }
            }
        }

        public void DestructionOfCards()
        {
            foreach (var card in cardsList)
            {
                Destroy(card);
            }

            cardsList.Clear();
        }

        private void SetTriggersListeners(GameObject buildingCard, BuildingData buildingData)
        {
            var holder = buildingCard.GetComponent<EventTrigger>();

            holder.triggers[0].callback.AddListener((_) => cardIsClick.Invoke(buildingData.gameObject));
            holder.triggers[1].callback.AddListener((_) => cardIsHeld.Invoke(true, buildingData.gameObject));
            holder.triggers[2].callback.AddListener((_) => cardIsHeld.Invoke(false, buildingData.gameObject));
        }

        private void SetCardInfo(GameObject buildingCard, BuildingData buildingData)
        {
            var cardData = buildingCard.GetComponent<CardData>();

            cardData.SetText(buildingData.title);
            cardData.SetImage(buildingData.icon);
        }
    }
}