using Cards;
using UnityEngine;

namespace Character
{
    [System.Serializable]
    public class EntityData
    {
        public string entityName;
        public Sprite sprite;
        public Sprite indicatorSprite;
        public int baseLife = 100;
        
        public DeckScriptable startingDeck = default;
        
        protected EntityData() { }
        public EntityData(EntityData data)
        {
            entityName = data.entityName;
            sprite = data.sprite;
            indicatorSprite = data.indicatorSprite;
            baseLife = data.baseLife;
            startingDeck = data.startingDeck;
        }
    }
}