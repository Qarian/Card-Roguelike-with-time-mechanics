using UI.Entities;
using UnityEngine;

namespace UI.Cards
{
    public class PlayableCardReceiver : MonoBehaviour, ICardReceiver
    {
        [SerializeField] private Character player;
        [SerializeField] private Character character;
        
        public bool CanReceiveCard(CardUI card)
        {
            return true;
        }

        public void ReceiveCard(CardUI card)
        {
            Debug.Log($"Used {card.data.title}!");
            card.UseCard(character);
        }
    }
}
