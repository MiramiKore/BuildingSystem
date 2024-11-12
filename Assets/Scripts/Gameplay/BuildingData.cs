using UnityEngine;

namespace Gameplay
{
    public class BuildingData : MonoBehaviour
    {
        public Vector2Int size;
        public Sprite icon;
        public string title;
        public TypeBuilding type;
    }
    
    public enum TypeBuilding
    {
        Base,
        Extraction
    }
}