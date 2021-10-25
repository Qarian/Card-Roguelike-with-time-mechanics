using UnityEngine;
using Utilities;

namespace UI.Cards
{
    public class PlayableCardReceiver : MonoBehaviour, ICardHolder
    {
        public bool CanReceiveCard(CardUI card)
        {
            return true;
        }

        public void ReceiveCard(CardUI card)
        {
            Debug.Log($"Used {card.data.title}!");
            card.SetParent(this, transform);
            //PoolsManager.Destroy(card);
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
