using System.Collections.Generic;
using HUD.GameModes.Interfaces;
using HUD.GameModes.Modes;
using UnityEngine;

namespace HUD.GameModes
{
    public class GameModeManager : MonoBehaviour, IGameModeManager
    {
        [SerializeField] private List<BaseGameMode> gameModes;
        public List<BaseGameMode> GameModes => gameModes; // Режимы игры
        
        private Dictionary<GameModeType, string> _modeTitles; // Названия игровых режимов
        
        public void Initialize()
        {
            // Создаем экземпляр словря с названиями игровых режимов
            _modeTitles = new Dictionary<GameModeType, string>
            {
                { GameModeType.Control, "Управление" },
                { GameModeType.Construction, "Строительство" },
                { GameModeType.Viewing, "Просмотр" }
            };
        }

        // Ищем и возвращаем игровой режим по его типу
        public BaseGameMode FindGameMode(GameModeType type)
        {
            return GameModes.Find(mode => mode.GetModeType() == type);
        }

        // Получаем и возвращаем название режима по его типу
        public string GetModeTitle(GameModeType type)
        {
            return _modeTitles.TryGetValue(type, out var title) ? title : string.Empty;
        }
    }
}