using HUD.ConstructionMode;
using HUD.ConstructionMode.TypesConstruction;
using HUD.GameModes;
using UnityEngine;

namespace HUD
{
    public class UIBootstrap : MonoBehaviour
    {
        private GameModeManager _gameModeManager;
        private SwitchingModsUI _switchingModsUI;
        private SetGameMode _setGameMode;

        private CardsOfBuildings _cardsOfBuildings;
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
            _cardsOfBuildings = FindAnyObjectByType<CardsOfBuildings>();
            _switchingBuildingTypes = FindAnyObjectByType<SwitchingBuildingTypes>();
            _buildingRegister = FindAnyObjectByType<BuildingRegister>();
            
            if (_cardsOfBuildings == null || _switchingBuildingTypes == null || _buildingRegister == null)
                Debug.LogWarning("Missing ConstructionModesInitialize component in UIBootstrap");
            
            _cardsOfBuildings.Initialize(_switchingModsUI, _switchingBuildingTypes, _buildingRegister);
        }
    }
}