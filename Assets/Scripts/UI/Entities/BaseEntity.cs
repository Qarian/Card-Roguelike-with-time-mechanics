using System;
using Cards;
using Cards.CardModifiers;
using Character;
using Encounter;
using Gameplay;
using Timing;
using UI.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Entities
{
    [RequireComponent(typeof(Modifiers))]
    public abstract class BaseEntity : MonoBehaviour, ICardReceiver
    {
        [SerializeField] protected Image image;
        public EntityData entityData;
        
        protected int currentHealth;
        protected Modifiers modifiers;
        protected Timer timer;

        public event Action OnEntityDeath;

        public Modifiers Modifiers => modifiers;
        public Timer Timer => timer;

        protected void Init()
        {
            currentHealth = entityData.baseLife;
            gameObject.name = entityData.entityName;
            image.sprite = entityData.sprite;
            
            modifiers = GetComponent<Modifiers>();
            modifiers.Initialize(this);
            if (timer is null)
            {
                Debug.LogWarning("Timer wasn't initiated", gameObject);
                timer = new Timer(0, CooldownEnd, false);
            }
        }

        public bool CanReceiveCard(CardUI card)
        {
            return true; // Check if card is attack card
        }
        
        public void ReceiveCard(CardUI card)
        {
            card.UseCard(this);
        }

        public void ModifyHealth(int amount)
        {
            currentHealth += amount;
            if (currentHealth <= 0)
            {
                KillEntity();
            }
        }

        private void KillEntity()
        {
            OnEntityDeath?.Invoke();
            Destroy(gameObject);
        }

        public abstract void StartCombat();

        protected abstract void CooldownEnd();
        

        public void UseCard(CardData card, BaseEntity target)
        {
            var action = card.PrepareAction();
            modifiers.UseCard(this, card, action);
            action.PerformAction(target);
            
            CombatManager.Instance.ActionPerformed();
            timer.IncreaseDuration(card.cost, true);
        }

        public void Defend(ActionData action)
        {
            // ToDo: Visual
            modifiers.Defend(this, action);
        }
    }
}