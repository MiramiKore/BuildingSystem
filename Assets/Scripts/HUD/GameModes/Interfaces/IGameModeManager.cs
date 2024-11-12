using System.Collections.Generic;
using HUD.GameModes.Modes;

namespace HUD.GameModes.Interfaces
{
    public interface IGameModeManager
    {
        public BaseGameMode FindGameMode(GameModeType type);
        public string GetModeTitle(GameModeType type);
        public List<BaseGameMode> GameModes { get; }
    }
}