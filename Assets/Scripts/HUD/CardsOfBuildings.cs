using System.Collections.Generic;
using Gameplay;
using HUD.GameModes;
using HUD.TypesConstruction;
using HUD.TypesConstruction.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace HUD
{
    public class CardsOfBuildings : MonoBehaviour, ICardsOfBuildings
    {
        [HideInInspector] public UnityEvent<bool> cardIsHeld;

        [SerializeField] private GameObject buildingCardPrefab;
        [SerializeField] private Transform locationInHierarchy;

        public List<GameObject> cardsList;

        private BuildingRegister _buildingRegister;
        private SwitchingBuildingTypes _switchingBuildingTypes;

        private void Awake()
        {
            _buildingRegister = FindAnyObjectByType<BuildingRegister>();
            
            FindAnyObjectByType<SwitchingModsUI>().gameModeSwitch.AddListener(CheckOfCards);
            FindAnyObjectByType<SwitchingBuildingTypes>().switchBuildingType.AddListener(CreationOfCards);
        }

        private void CheckOfCards(GameMode gameMode)
        {
            if (gameMode.Type == GameModeType.Construction)
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
            
            foreach (var data in _buildingRegister.buildingsData)
            {
                if (data.type == type)
                {
                    var buildingCard = Instantiate(buildingCardPrefab, locationInHierarchy);

                    SetCardInfo(buildingCard, data);
                
                    SetTriggersListeners(buildingCard);
                
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

        private void SetTriggersListeners(GameObject buildingCard)
        {
            var holder = buildingCard.GetComponent<EventTrigger>();
            
            holder.triggers[0].callback.AddListener((_) => cardIsHeld.Invoke(true));
            holder.triggers[1].callback.AddListener((_) => cardIsHeld.Invoke(false));
        }

        private void SetCardInfo(GameObject buildingCard, BuildingData data)
        {
            var cardData = buildingCard.GetComponent<CardData>();
                    
            cardData.SetText(data.title);
            cardData.SetImage(data.icon);
        }
    }
}