using System.Collections.Generic;
using System.Linq;
using Cards.CardModifiers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card/Data", fileName = "New Card Data")]
    public class CardDataScriptable : SerializedScriptableObject
    {
        public CardStyle style = null;
        public string title = string.Empty;
        public float cost = -1;
        [Multiline]
        public string description = string.Empty;

        public List<ModifierWithDataScriptable> actions = new();

        public List<ModifierWithData> Actions => actions.ToList().ConvertAll(x => (ModifierWithData) x);

        public static implicit operator CardData(CardDataScriptable c) => new CardData(c);
    }
}
