using Cards;
using Character;
using Encounter;
using Timing;
using UI.Timeline;
using UnityEngine;

namespace UI.Entities
{
    public class PlayerEntity : BaseEntity
    {
        [SerializeField] private PlayerDataScriptable dataScriptable;

        [HideInInspector]
        public Deck temporaryDeck;
        [HideInInspector]
        public Deck discardDeck;
        
        
        private PlayerData Data => (PlayerData) entityData;

        public void Initialize()
        {
            entityData = dataScriptable;
            Data.permanentDeck = new Deck(entityData.startingDeck.cards, this);
            
            temporaryDeck = new Deck(Data.permanentDeck);
            discardDeck = new Deck(this);

            timer = new Timer(0, CooldownEnd, false);
            EntityTimeline.Instance.TrackEntity(this, Color.white);
            
            base.Init();
        }

        public override void StartCombat()
        {
            temporaryDeck = new Deck(Data.permanentDeck);
            discardDeck = new Deck(this);
        }

        protected override void CooldownEnd()
        {
            CombatManager.Instance.EnablePlayerActions();
        }
    }
}