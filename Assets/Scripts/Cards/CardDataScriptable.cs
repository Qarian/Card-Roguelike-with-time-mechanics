using Cards.Actions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card/Data", fileName = "New Card Data")]
    public class CardDataScriptable : SerializedScriptableObject
    {
        public CardStyle style = null;
        public string title = string.Empty;
        public int cost = -1;
        [Multiline]
        public string description = string.Empty;

        public ICardAction[] actions;

        public static implicit operator CardData(CardDataScriptable c) => new CardData(c);
    }
}
