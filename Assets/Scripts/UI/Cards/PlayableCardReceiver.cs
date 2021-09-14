using UnityEngine;
using Utilities;

namespace UI.Cards
{
    public class PlayableCardReceiver : MonoBehaviour, ICardHolder
    {
        public bool ReceiveCard(CardUI card)
        {
            Debug.Log($"Used {card.data.title}!");
            PoolsManager.Destroy(card);
            return true;
        }

        public void ReturnCard(CardUI card)
        {
            Debug.LogError("Card returned to ");
        }
    }
}
