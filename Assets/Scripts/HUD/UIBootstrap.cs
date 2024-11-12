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
                Debug.LogWarning("Missing GameModesInitialize component in UIBootstrap");
            
            _gameModeManager.Initialize();
            _setGameMode.Initialize(_gameModeManager, _switchingModsUI);
            _switchingModsUI.Initialize(_gameModeManager);
        }

        private void ConstructionModesInitialize()
        {
            _cardsManager = FindAnyObjectByType<CardsManager>();
            _switchingBuildingTypes = FindAnyObjectByType<SwitchingBuildingTypes>();
            _buildingRegister = FindAnyObjectByType<BuildingRegister>();
            
            if (_cardsManager == null || _switchingBuildingTypes == null || _buildingRegister == null)
                Debug.LogWarning("Missing ConstructionModesInitialize component in UIBootstrap");
            
            _cardsManager.Initialize(_switchingModsUI, _switchingBuildingTypes, _buildingRegister);
        }
    }
}