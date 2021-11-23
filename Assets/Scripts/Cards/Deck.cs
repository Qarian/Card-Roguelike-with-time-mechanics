using System;
using System.Collections.Generic;
using UI.Entities;
using UnityEngine;

namespace Cards
{
    [Serializable]
    public class Deck
    {
        public readonly List<CardData> cards;
        public int Size => cards.Count;

        [SerializeField] private Character owner = default;

        public Deck(List<CardDataScriptable> baseCards)
        {
            cards = new List<CardData>(baseCards.Count);
            foreach (var t in baseCards)
            {
                CardData card = t;
                card.owner = owner;
                cards.Add(t);
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
