using UI.Entities;
using UnityEngine;

namespace UI.Cards
{
    public class PlayableCardReceiver : MonoBehaviour, ICardReceiver
    {
        [SerializeField] private EntityData player;
        [SerializeField] private EntityData entityData;
        
        public bool CanReceiveCard(CardUI card)
        {
            return true;
        }

        public void ReceiveCard(CardUI card)
        {
            Debug.Log($"Used {card.data.title}!");
            card.UseCard(entityData);
        }
    }
}
