using System;
using System.Collections.Generic;
using System.Linq;
using UI.Entities;
using Random = UnityEngine.Random;

namespace Cards
{
    [Serializable]
    public class Deck
    {
        public readonly List<CardData> cards;
        public int Size => cards.Count;

        private BaseEntity owner;

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

        public Deck(Deck originalDeck)
        {
            cards = originalDeck.cards.ToArray().ToList();
            owner = originalDeck.owner;
        }

        public Deck(BaseEntity owner)
        {
            cards = new();
            this.owner = owner;
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

        public CardData TakeLastCard()
        {
            CardData card = cards[^1];
            RemoveCard(card);
            return card;
        }

        public void Shuffle()
        {
            int n = cards.Count;  
            while (n > 1) {  
                n--;
                int k = Random.Range(0, n + 1);  
                (cards[k], cards[n]) = (cards[n], cards[k]);
            } 
        }

        public void MoveCards(Deck targetDeck)
        {
            foreach (var card in cards)
            {
                targetDeck.AddCard(card);
            }
            cards.Clear();
        }
    }
}
