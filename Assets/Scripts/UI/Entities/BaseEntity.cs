using System;
using Cards.CardModifiers;
using UI.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Entities
{
    [RequireComponent(typeof(Modifiers))]
    public class BaseEntity : MonoBehaviour, ICardReceiver
    {
        [SerializeField] private Image image;
        [SerializeField] // serialized only for debug
        private EntityData entityData;

        private Modifiers modifiers;

        private void Awake()
        {
            image.sprite = entityData.sprite;
            modifiers.Initialize(this);
        }

        public bool CanReceiveCard(CardUI card)
        {
            return true; //Check if card is attack card
        }
        
        public void ReceiveCard(CardUI card)
        {
            card.UseCard(entityData);
        }
        
    }
}