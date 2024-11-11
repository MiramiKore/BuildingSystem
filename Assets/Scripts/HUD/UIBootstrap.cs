using HUD.GameModes;
using UnityEngine;

namespace HUD
{
    public class UIBootstrap : MonoBehaviour
    {
        private GameModeManager _gameModeManager;
        private SwitchingModsUI _switchingModsUI;
        private SetGameMode _setGameMode;
        
        private void Awake()
        {
            GameModesInitialize();
        }

        private void GameModesInitialize()
        {
            _gameModeManager = FindAnyObjectByType<GameModeManager>();
            _switchingModsUI = FindAnyObjectByType<SwitchingModsUI>();
            _setGameMode = FindAnyObjectByType<SetGameMode>();
            
            _gameModeManager.Initialize();
            _setGameMode.Initialize(_gameModeManager, _switchingModsUI);
            _switchingModsUI.Initialize(_gameModeManager);
        }
    }
}