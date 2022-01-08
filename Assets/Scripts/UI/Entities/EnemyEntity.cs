using Cards;
using Character;
using Encounter;
using Timing;
using UnityEngine;

namespace UI.Entities
{
    public class EnemyEntity : BaseEntity
    {
        private EnemyData Data => (EnemyData) entityData;
        
        private CardData currentCard;

        public void Init(EnemyData data)
        {
            entityData = data;
            timer = new Timer(data.initialCooldown, CooldownEnd, false);

            currentCard = Data?.firstCard ?? ChooseNextCard();
            currentHealth = Data.baseLife;
            
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
            UseCard(currentCard, EncounterManager.Player);
            currentCard = ChooseNextCard();
        }
    }
}