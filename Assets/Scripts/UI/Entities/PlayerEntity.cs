using Cards;
using Character;
using Managers;
using Timing;
using UI.Timeline;
using UnityEngine;
using Zenject;

namespace UI.Entities
{
    public class PlayerEntity : BaseEntity
    {
        [HideInInspector]
        public Deck temporaryDeck;
        [HideInInspector]
        public Deck discardDeck;

        public int cardsInHand = 3;

        [Inject]
        private EncounterManager encounterManager;
        
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
            discardDeck = new Deck(null, this);

            timer = new Timer(0, CooldownEnd, false);
            EntityTimeline.Instance.TrackEntity(this, Color.white);
            
            base.Init();
        }

        public override void ModifyHealth(int amount)
        {
            base.ModifyHealth(amount);
            Data.currentHealth = currentHealth;
        }

        protected override void CooldownEnd()
        {
            encounterManager.EnablePlayerActions();
        }

        public CardData GetCard()
        {
            if (temporaryDeck.Size > 0)
                return temporaryDeck.TakeLastCard();
            else
            {
                if (discardDeck.Size == 0)
                    throw new UnityException("No cards to take from!");
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