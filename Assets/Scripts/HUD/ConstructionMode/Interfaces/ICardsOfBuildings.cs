using HUD.Data;

namespace HUD.ConstructionMode.Interfaces
{
    public interface ICardsOfBuildings
    {
        public void CreationOfCards(TypeBuilding type);
        public void DestructionOfCards();
    }
}