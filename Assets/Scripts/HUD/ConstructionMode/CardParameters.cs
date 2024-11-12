using Gameplay.BuildingSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace HUD.ConstructionMode
{
    public class CardParameters : MonoBehaviour
    {
        // Взаимодействие с карточкой
        [HideInInspector] public UnityEvent<GameObject> cardIsClick;
        [HideInInspector] public UnityEvent<bool, GameObject> cardIsHeld;
        
        public void Initialize(CardsManager cardsManager)
        {
            cardsManager.cardIsCreated.AddListener(SetCardParameters);
        }

        // Устанавливаем параметры карточки
        private void SetCardParameters(GameObject card, BuildingData data)
        {
            SetCardInfo(card, data);
            SetTriggersListeners(card, data);
        }
        
        // Устанавливаем информацию на карточке
        private void SetCardInfo(GameObject buildingCard, BuildingData buildingData)
        {
            var cardData = buildingCard.GetComponent<CardData>();

            cardData.SetText(buildingData.title);
            cardData.SetImage(buildingData.icon);
        }
        
        // Устанавливаем слушателей на взамсодействие с карточкой
        private void SetTriggersListeners(GameObject card, BuildingData data)
        {
            var holder = card.GetComponent<EventTrigger>();
            
            holder.triggers[0].callback.AddListener((_) => cardIsClick.Invoke(data.gameObject));
            holder.triggers[1].callback.AddListener((_) => cardIsHeld.Invoke(true, data.gameObject));
            holder.triggers[2].callback.AddListener((_) => cardIsHeld.Invoke(false, data.gameObject));
        }
    }
}