using Cards.CardModifiers;
using UI.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Entities
{
    [RequireComponent(typeof(Modifiers))]
    public class BaseEntity : MonoBehaviour, ICardReceiver
    {
        [SerializeField] protected Image image;
        [SerializeField] // Serialized only for debug
        protected EntityData entityData;
        
        protected int currentHealth;
        private Modifiers modifiers;

        public Modifiers Modifiers => modifiers;

        private void Awake()
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
            card.UseCard(entityData);
        }

        public void ModifyHealth(int amount)
        {
            currentHealth += amount;
            if (currentHealth <= 0)
            {
                // Kill Entity
            }
        }
    }
}