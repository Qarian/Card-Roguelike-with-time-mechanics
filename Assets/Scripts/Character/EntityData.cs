using Cards;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.Entities
{
    [CreateAssetMenu(menuName = "Characters/Blank Character")]
    public class EntityData : ScriptableObject
    {
        public string entityName;
        public Sprite sprite;
        public int baseLife = 100;
        
        public DeckScriptable startingDeck = default;
    }
}