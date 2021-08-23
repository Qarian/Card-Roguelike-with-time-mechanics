using System.Collections.Generic;

namespace Cards
{
    public class Deck
    {
        public readonly List<CardData> cards;
        public int Size => cards.Count;

        public Deck(List<CardData> baseCards)
        {
            cards = new List<CardData>(baseCards);
        }
    }
}
