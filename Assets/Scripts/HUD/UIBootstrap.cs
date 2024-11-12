using HUD.ConstructionMode;
using HUD.ConstructionMode.TypesOfBuildings;
using HUD.GameModes;
using UnityEngine;

namespace HUD
{
    public class UIBootstrap : MonoBehaviour
    {
        private GameModeManager _gameModeManager;
        private SwitchingModsUI _switchingModsUI;
        private SetGameMode _setGameMode;

        private CardsManager _cardsManager;
        private CardParameters _cardParameters;
        private SwitchingBuildingTypes _switchingBuildingTypes;
        private BuildingRegister _buildingRegister;

        private void Awake()
        {
            GameModesInitialize();
            ConstructionModesInitialize();
        }

        private void GameModesInitialize()
        {
            _gameModeManager = FindAnyObjectByType<GameModeManager>();
            _switchingModsUI = FindAnyObjectByType<SwitchingModsUI>();
            _setGameMode = FindAnyObjectByType<SetGameMode>();

            if (_gameModeManager == null || _switchingModsUI == null || _setGameMode == null)
                Debug.LogWarning("Missing GameModes component");

            _gameModeManager.Initialize();
            _setGameMode.Initialize(_gameModeManager, _switchingModsUI);
            _switchingModsUI.Initialize(_gameModeManager);
        }

        private void ConstructionModesInitialize()
        {
            _cardsManager = FindAnyObjectByType<CardsManager>();
            _cardParameters = FindAnyObjectByType<CardParameters>();
            _switchingBuildingTypes = FindAnyObjectByType<SwitchingBuildingTypes>();
            _buildingRegister = FindAnyObjectByType<BuildingRegister>();

            if (_cardsManager == null || _switchingBuildingTypes == null || _buildingRegister == null)
                Debug.LogWarning("Missing ConstructionModes component");

            _cardsManager.Initialize(_switchingModsUI, _switchingBuildingTypes, _buildingRegister);
            _cardParameters.Initialize(_cardsManager);
        }
    }
}