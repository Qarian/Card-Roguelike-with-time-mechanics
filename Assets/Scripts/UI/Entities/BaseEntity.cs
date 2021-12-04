using Cards;
using Cards.CardModifiers;
using Character;
using UI.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Entities
{
    [RequireComponent(typeof(Modifiers))]
    public class BaseEntity : MonoBehaviour, ICardReceiver
    {
        [SerializeField] protected Image image;
        protected EntityData entityData;
        
        protected int currentHealth;
        private Modifiers modifiers;

        public Modifiers Modifiers => modifiers;

        protected void Init()
        {
            currentHealth = entityData.baseLife;
            gameObject.name = entityData.entityName;
            image.sprite = entityData.sprite;
            
            modifiers = GetComponent<Modifiers>();
            modifiers.Initialize(this);
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
                // Kill Entity
            }
        }

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