using Cards;
using Character;
using UnityEngine;

namespace UI.Entities
{
    public class PlayerEntity : BaseEntity
    {
        [SerializeField] private PlayerDataScriptable dataScriptable;
        private PlayerData data => (PlayerData) entityData;

        public void Initialize()
        {
            entityData = dataScriptable;
            data.permanentDeck = new Deck(entityData.startingDeck.cards, this);
            data.temporaryDeck = new Deck(entityData.startingDeck.cards, this);
            
            base.Init();
        }
    }
}