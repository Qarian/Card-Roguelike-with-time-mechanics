using System;
using Cards;
using Cards.CardModifiers;
using Character;
using Timing;
using UI.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Entities
{
    [RequireComponent(typeof(Modifiers))]
    public class BaseEntity : MonoBehaviour, ICardReceiver
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
            timer = new Timer(0, CooldownEnd, true);
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
        
        protected virtual void CooldownEnd() { }

        public void UseCard(CardData card, BaseEntity target)
        {
            var action = card.PrepareAction();
            modifiers.UseCard(this, card, action);
            action.PerformAction(target);
        }

        public void Defend(ActionData action)
        {
            // ToDo: Visual
            modifiers.Defend(this, action);
        }
    }
}