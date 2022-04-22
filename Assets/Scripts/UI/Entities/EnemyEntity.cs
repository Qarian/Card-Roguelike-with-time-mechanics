using Cards;
using Character;
using Managers;
using Timing;
using UI.Cards;
using UnityEngine;
using Zenject;

namespace UI.Entities
{
    public class EnemyEntity : BaseEntity
    {
        private EnemyData Data => (EnemyData) entityData;
        
        private CardData currentCard;

        private PlayerEntity player;

        [Inject]
        private void Inject(PlayerEntity playerEntity)
        {
            player = playerEntity;
        }

        public void Init(EnemyData data, float difficulty)
        {
            entityData = data;
            currentCard = Data?.firstCard ?? ChooseNextCard();
            
            timer = new Timer(data.initialCooldown + currentCard.cost + Random.Range(0, 1f), CooldownEnd, false);
            timer.internalModifier = difficulty;

            currentHealth = Data.baseLife;
            healthBar.Init(entityData.baseLife);
            
            base.Init();
        }

        public override void StartCombat()
        {
            timer.Start(false);
        }

        private CardData ChooseNextCard()
        {
            return Data.startingDeck[Random.Range(0, Data.startingDeck.Count)];
        }

        protected override void CooldownEnd()
        {
            UseCard(currentCard, currentCard.selfCastAsEnemy ? this : player);
            currentCard = ChooseNextCard();
            timer.IncreaseDuration(currentCard.cost);
        }

        public class Factory : PlaceholderFactory<EnemyEntity> { }
    }
}