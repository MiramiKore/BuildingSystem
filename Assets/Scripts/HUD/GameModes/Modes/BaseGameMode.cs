using UnityEngine;

namespace HUD.GameModes.Modes
{
    public enum GameModeType
    {
        Control,
        Construction,
        Viewing
    }
    
    public class BaseGameMode : MonoBehaviour
    {
        [SerializeField] private GameModeType type;

        public GameModeType GetModeType()
        {
            return type;
        }
    }
}