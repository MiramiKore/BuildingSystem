using HUD.GameModes.Interfaces;
using TMPro;
using UnityEngine;

namespace HUD.GameModes
{
    public class SetGameMode : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI modeTitle; // Название режима

        private IGameModeManager _gameModeManager;
        
        public void Initialize(GameModeManager gameModeManager, SwitchingModsUI switchingModsUI)
        {
            _gameModeManager = gameModeManager;
            
            switchingModsUI.gameModeSwitch.AddListener(SetMode);
        }
        
        // Устанавливаем текущий режим игры
        private void SetMode(GameMode currentMode)
        {
            modeTitle.text = _gameModeManager.GetModeTitle(currentMode.Type);
            currentMode.UI.SetActive(true);
        }
    }
}