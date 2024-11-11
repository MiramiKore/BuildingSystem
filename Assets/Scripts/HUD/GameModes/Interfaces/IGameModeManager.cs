using System.Collections.Generic;

namespace HUD.GameModes.Interfaces
{
    public interface IGameModeManager
    {
        public GameMode FindGameMode(GameModeType type);
        public string GetModeTitle(GameModeType type);
        public List<GameMode> GameModes { get;}
    }
}