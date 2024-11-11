using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "BuildingName",menuName = "Scriptables/Building")]
    public class BuildingData : ScriptableObject
    {
        public GameObject prefab;
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