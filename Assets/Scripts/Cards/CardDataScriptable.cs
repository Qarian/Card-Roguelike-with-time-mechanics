using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card/Data", fileName = "New Card Data")]
    public class CardDataScriptable : ScriptableObject
    {
        public CardStyle style = null;
        public string title = string.Empty;
        public int cost = -1;
        [Multiline]
        public string description = string.Empty;

        public static implicit operator CardData(CardDataScriptable c) => new CardData(c);
    }
}
