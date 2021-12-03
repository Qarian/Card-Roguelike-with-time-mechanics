using Cards;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.Entities
{
    [CreateAssetMenu(menuName = "Characters/Blank Character")]
    public class EntityData : ScriptableObject
    {
        [Required]
        public Sprite sprite;
        
        [SerializeField] private int baseLife = 100;
        
        [Required]
        public DeckScriptable startingDeck = default;
    }
}