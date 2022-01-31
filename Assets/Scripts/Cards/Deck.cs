using System.Collections.Generic;
using System.Linq;
using UI.Entities;
using Random = UnityEngine.Random;

namespace Cards
{
    public class Deck
    {
        public readonly List<CardData> cards = new ();
        public int Size => cards.Count;

        private BaseEntity owner;

        public Deck(List<CardDataScriptable> cards, BaseEntity owner = null)
        {
            if (cards == null) return;
            
            foreach (CardDataScriptable t in cards)
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

        // Fisher–Yates shuffle
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
            foreach (CardData card in cards)
            {
                targetDeck.AddCard(card);
            }
            cards.Clear();
        }

        public void SetOwner(BaseEntity newOwner)
        {
            owner = newOwner;
            
            foreach (CardData card in cards)
            {
                card.owner = newOwner;
            }
        }
    }
}
