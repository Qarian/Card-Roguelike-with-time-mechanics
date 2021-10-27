using Entity;
using UnityEngine;
using Utilities;

namespace UI.Cards
{
    public class PlayableCardReceiver : MonoBehaviour, ICardHolder
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
            card.SetParent(this, transform);
            character.ApplyAction(card.data.PrepareAttack());
            PoolsManager.Remove(card);
        }

        public void DragCard(CardUI card)
        {
            Debug.LogError($"Unsupported DragCard on {name}", gameObject);
        }

        public void RemoveCard(CardUI card)
        {
            Debug.LogError($"Unsupported RemoveCard on {name}", gameObject);
        }

        public void ReturnCard(CardUI card)
        {
            Debug.LogError($"Unsupported ReturnCard on {name}", gameObject);
        }
    }
}
