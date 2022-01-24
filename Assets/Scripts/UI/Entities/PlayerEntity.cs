using Cards;
using Character;
using Managers;
using Timing;
using UI.Timeline;
using UnityEngine;

namespace UI.Entities
{
    public class PlayerEntity : BaseEntity
    {
        [HideInInspector]
        public Deck temporaryDeck;
        [HideInInspector]
        public Deck discardDeck;

        public int cardsInHand = 3;
        
        private PlayerData Data => (PlayerData) entityData;

        public void Initialize()
        {
            entityData = PlayerGlobalData.Current;
            Data.Init(this);
            currentHealth = Data.currentHealth;
            healthBar.Init(Data.maxHealth, Data.currentHealth);
            
            temporaryDeck = new Deck(Data.permanentDeck);
            temporaryDeck.SetOwner(this);
            temporaryDeck.Shuffle();
            discardDeck = new Deck(this);

            timer = new Timer(0, CooldownEnd, false);
            EntityTimeline.Instance.TrackEntity(this, Color.white);
            
            base.Init();
        }

        public override void StartCombat()
        {
            
        }

        public override void ModifyHealth(int amount)
        {
            base.ModifyHealth(amount);
            Data.currentHealth = currentHealth;
        }

        protected override void CooldownEnd()
        {
            EncounterManager.Instance.EnablePlayerActions();
        }

        public CardData GetCard()
        {
            if (temporaryDeck.Size > 0)
                return temporaryDeck.TakeLastCard();
            else
            {
                discardDeck.MoveCards(temporaryDeck);
                temporaryDeck.Shuffle();
                return GetCard();
            }
        }

        public override void UseCard(CardData card, BaseEntity target)
        {
            base.UseCard(card, target);
            
            timer.IncreaseDuration(card.cost);
        }

        public void DiscardCard(CardData card)
        {
            discardDeck.AddCard(card);
        }
    }
}