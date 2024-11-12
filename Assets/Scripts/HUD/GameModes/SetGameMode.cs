using HUD.GameModes.Interfaces;
using HUD.GameModes.Modes;
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
        private void SetMode(BaseGameMode currentMode)
        {
            modeTitle.text = _gameModeManager.GetModeTitle(currentMode.GetModeType());
            currentMode.gameObject.SetActive(true);
        }
    }
}