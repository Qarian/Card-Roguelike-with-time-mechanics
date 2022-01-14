using System.Collections.Generic;
using System.Linq;
using Cards;
using Managers;
using UI.Cards;
using UnityEngine;

namespace UI.PostCombat
{
    public class CardSelectionWindow : PostCombatWindow
    {
        [SerializeField] private DeckScriptable cardsPool;
        [SerializeField] private UICardClickable cardPrefab = default;
        
        [Space]
        [SerializeField] private Transform parent = default;

        [Space]
        [SerializeField] private int cardsCount;

        public override void ShowWindow()
        {
            CreateCards(cardsPool.cards.OrderBy(x => Random.Range(0f, 1f)).Take(cardsCount).ToList());
            
            gameObject.SetActive(true);
        }

        private void CreateCards(List<CardDataScriptable> cards)
        {
            foreach (CardData cardData in cards)
            {
                UICardClickable cardUI = Instantiate(cardPrefab, parent);
                cardUI.Init(cardData, () => OnClick(cardData));
            }
        }

        private void OnClick(CardData cardData)
        {
            Deck deck = PlayerGlobalData.Current.permanentDeck;
            deck.AddCard(cardData);
            
            Finalize();
        }
    }
}