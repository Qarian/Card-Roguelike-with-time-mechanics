using System;
using System.Collections.Generic;
using UI.Entities;

namespace Cards
{
    [Serializable]
    public class Deck
    {
        public readonly List<CardData> cards;
        public int Size => cards.Count;

        private BaseEntity owner = default;

        public Deck(List<CardDataScriptable> cards, BaseEntity owner)
        {
            this.cards = new List<CardData>(cards.Count);
            foreach (var t in cards)
            {
                CardData card = t;
                card.owner = owner;
                this.cards.Add(card);
            }
        }

        public void AddCard(CardData card)
        {
            card.owner = owner;
            cards.Add(card);
        }
        
        public void RemoveCard(CardData card)
        {
            cards.Remove(card);
        }
    }
}
