using System.Collections.Generic;
using HUD.GameModes.Interfaces;
using UnityEngine;

namespace HUD.GameModes
{
    public class GameModeManager : MonoBehaviour, IGameModeManager
    {
        public List<GameMode> GameModes { get; private set; } // Режимы игры
        
        private Dictionary<GameModeType, string> _modeTitles; // Названия игровых режимов
        
        [SerializeField] private GameObject[] gameModesUI; // Интерфейсы режимов игры
        
        public void Initialize()
        {
            // Создаем экземпляр списка с игровыми режимами
            GameModes = new List<GameMode>()
            {
                new GameMode(GameModeType.Control, gameModesUI[0]),
                new GameMode(GameModeType.Construction, gameModesUI[1]),
                new GameMode(GameModeType.Viewing, gameModesUI[2])
            };
            
            // Создаем экземпляр словря с названиями игровых режимов
            _modeTitles = new Dictionary<GameModeType, string>
            {
                { GameModeType.Control, "Управление" },
                { GameModeType.Construction, "Строительство" },
                { GameModeType.Viewing, "Просмотр" }
            };
        }

        // Ищем и возвращаем игровой режим по его типу
        public GameMode FindGameMode(GameModeType type)
        {
            return GameModes.Find(mode => mode.Type == type);
        }

        // Получаем и возвращаем название режима по его типу
        public string GetModeTitle(GameModeType type)
        {
            return _modeTitles.TryGetValue(type, out var title) ? title : string.Empty;
        }
    }
}