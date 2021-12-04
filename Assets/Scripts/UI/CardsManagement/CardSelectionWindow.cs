using System.Collections.Generic;
using Cards;
using Character;
using Sirenix.OdinInspector;
using UI.Cards;
using UnityEngine;
using Utilities;

namespace UI.CardsManagement
{
    public class CardSelectionWindow : Singleton<CardSelectionWindow>
    {
        [SerializeField] private UICardClickable cardPrefab = default;
        [SerializeField] private PlayerDataScriptable player;
        [SerializeField] private Transform parent = default;

        private int availablePicks;
        private bool create;

        [Button]
        public void CardsToAdd(List<CardData> cards, bool temporary, int availablePicks = 1)
        {
            if (gameObject.activeSelf)
                return;
            gameObject.SetActive(true);

            create = true;
            this.availablePicks = availablePicks;
            CreateCards(cards, temporary);
        }

        [Button]
        private void CardsToDelete(List<CardData> cards, bool temporary, int availablePicks = 1)
        {
            if (gameObject.activeSelf)
                return;
            gameObject.SetActive(true);

            create = false;
            this.availablePicks = availablePicks;
            CreateCards(cards, temporary);
        }

        private void CreateCards(List<CardData> cards, bool temporary)
        {
            foreach (CardData cardData in cards)
            {
                UICardClickable cardUI = Instantiate(cardPrefab, parent);
                cardUI.Init(cardData, () => OnClick(cardUI, cardData, temporary));
            }
        }

        private void OnClick(UICardClickable cardUI, CardData cardData, bool temporary)
        {
            Deck deck = temporary ? player.data.temporaryDeck : player.data.permanentDeck;
            if (create)
                deck.AddCard(cardData);
            else
                deck.RemoveCard(cardData);

            availablePicks--;
            if (availablePicks <= 0)
            {
                foreach (Transform childCard in parent)
                {
                    PoolsManager.Remove(childCard.GetComponent<UICardClickable>());
                }

                gameObject.SetActive(false);
            }
            else
            {
                PoolsManager.Remove(cardUI);
            }
        }
    }
}