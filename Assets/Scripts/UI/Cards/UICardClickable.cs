using Cards;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilities;

namespace UI.Cards
{
    [RequireComponent(typeof(CardUI))]
    public class UICardClickable : PoolableMonoBehaviour
    {
        private CardUI card;
        [SerializeField] private Button button;

        public void Init(CardData cardData, UnityAction action)
        {
            if (!card)
                card = GetComponent<CardUI>();

            card.SetCard(cardData);
            button.onClick.AddListener(action);
        }
    }
}