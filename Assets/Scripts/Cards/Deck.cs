using System.Collections.Generic;

namespace Cards
{
    public class Deck
    {
        public readonly List<CardData> cards;
        public int Size => cards.Count;

        public Deck(List<CardDataScriptable> baseCards)
        {
            cards = new List<CardData>(baseCards.Count);
            foreach (var t in baseCards)
            {
                cards.Add(t);
            }
        }

        public void AddCard(CardData card)
        {
            cards.Add(card);
        }
        
        public void RemoveCard(CardData card)
        {
            cards.Remove(card);
        }
    }
}
