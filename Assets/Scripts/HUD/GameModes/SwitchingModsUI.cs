using HUD.GameModes.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HUD.GameModes
{
    public class SwitchingModsUI : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<GameMode> gameModeSwitch; // Событие смены режима

        // Кнопки переключения режимов
        [SerializeField] private Button previousModeButton;
        [SerializeField] private Button nextModeButton;
        
        // Текущий режим игры и его индекс
        private GameMode _currentMode;
        private int _currentModeIndex;
        
        private IGameModeManager _gameModeManager;
        
        public void Initialize(GameModeManager gameModeManager)
        {
            _gameModeManager = gameModeManager;
            
            nextModeButton.onClick.AddListener(NextMod);
            previousModeButton.onClick.AddListener(PreviousMode);
            
            // В начале игры устанавливаем текущим режимом игры - управление
            SwitchMod(_gameModeManager.GameModes[0]);
        }
        
        // Следующий режим игры
        private void NextMod()
        {
            var gameModes = _gameModeManager.GameModes;

            _currentModeIndex = (_currentModeIndex + 1) % gameModes.Count;
            SwitchMod(gameModes[_currentModeIndex]);
        }

        // Предыдущий режим игры
        private void PreviousMode()
        {
            var gameModes = _gameModeManager.GameModes;

            _currentModeIndex = (_currentModeIndex - 1 + gameModes.Count) % gameModes.Count;
            SwitchMod(gameModes[_currentModeIndex]);
        }

        // Переключение режима игры
        private void SwitchMod(GameMode newGameMode)
        {
            _currentMode?.UI.SetActive(false);

            _currentMode = newGameMode;

            gameModeSwitch.Invoke(_currentMode);
        }
    }
}