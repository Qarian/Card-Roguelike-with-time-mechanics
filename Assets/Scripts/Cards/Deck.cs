using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card/Deck", fileName = "New Deck")]
    public class Deck : ScriptableObject
    {
        public List<CardData> cards;
    }
}
