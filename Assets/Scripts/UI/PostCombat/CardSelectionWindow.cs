using System;
using System.Collections.Generic;
using System.Linq;
using Cards;
using Managers;
using UI.Cards;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI.PostCombat
{
    public class CardSelectionWindow : MonoBehaviour, IPostCombatWindow
    {
        [SerializeField] private Deck cardsPool;
        [SerializeField] private UICardClickable cardPrefab = default;
        
        [Space]
        [SerializeField] private Transform parent = default;

        [Space]
        [SerializeField] private int cardsCount;
        
        public event Action OnWindowFinalized;
        
        public void ShowWindow()
        {
            CreateCards(cardsPool.cards.OrderBy(x => Random.Range(0f, 1f)).Take(cardsCount).ToList());
            
            gameObject.SetActive(true);
        }

        public void CloseWindow()
        {
            gameObject.SetActive(false);
        }

        private void CreateCards(List<CardData> cards)
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
            
            OnWindowFinalized.Invoke();
        }
    }
}