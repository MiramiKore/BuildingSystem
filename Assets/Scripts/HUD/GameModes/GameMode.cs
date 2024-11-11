using UnityEngine;

namespace HUD.GameModes
{
    public enum GameModeType
    {
        Control,
        Construction,
        Viewing
    }
    
    public class GameMode
    {
        public GameModeType Type { get; private set; }
        public GameObject UI { get; private set; }
        
        public GameMode(GameModeType type, GameObject ui)
        {
            Type = type;
            UI = ui;
        }
    }
}