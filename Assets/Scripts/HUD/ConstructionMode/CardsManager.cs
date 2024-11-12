using System.Collections.Generic;
using Gameplay.BuildingSystem;
using HUD.ConstructionMode.TypesOfBuildings;
using HUD.GameModes;
using HUD.GameModes.Modes;
using UnityEngine;
using UnityEngine.Events;

namespace HUD.ConstructionMode
{
    public class CardsManager : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<GameObject, BuildingData> cardIsCreated; // Карточка была создана
        
        // Префаб карточки постройки и его располодение на сцене
        [SerializeField] private GameObject buildingCardPrefab;
        [SerializeField] private Transform locationInHierarchy;

        public List<GameObject> cardsList; // Список текуших карточек

        private BuildingRegister _buildingRegister;

        public void Initialize(SwitchingModsUI switchingModsUI, SwitchingBuildingTypes switchingBuildingTypes,
            BuildingRegister buildingRegister)
        {
            switchingModsUI.gameModeSwitch.AddListener(CheckOfCards);
            switchingBuildingTypes.switchBuildingType.AddListener(CreationOfCards);
            
            _buildingRegister = buildingRegister;
        }

        // Управление карточками взависимости от текущего режима игры
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

        // Создаем карточки
        private void CreationOfCards(TypeBuilding type)
        {
            DestructionOfCards();

            foreach (var buildingData in _buildingRegister.buildingsData)
            {
                if (buildingData.type != type) continue;
                
                var buildingCard = Instantiate(buildingCardPrefab, locationInHierarchy);

                cardsList.Add(buildingCard);
                
                cardIsCreated.Invoke(buildingCard, buildingData);
            }
        }

        // Уничтожаем карточки
        private void DestructionOfCards()
        {
            foreach (var card in cardsList)
            {
                Destroy(card);
            }

            cardsList.Clear();
        }
    }
}