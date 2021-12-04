using System;
using Cards.CardModifiers.Effects;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UI.Entities;
using UnityEngine;

namespace Cards.CardModifiers
{
    public class Modifier
    {
        [Required]
        public string name;

        [Header("Events")]
        [OdinSerialize] private ICardUsageEffect[] onUsingCard;
        [OdinSerialize] private IDefendEffect[] onDefending;
        [OdinSerialize] private ICharacterEffect[] onAttacking;
        [Space]
        [OdinSerialize] private ICharacterEffect[] onTimeTick;
        
        public bool UseTimer => onTimeTick.Length > 0;
        public bool CanBeAssigned => onTimeTick.Length > 0 || onUsingCard.Length > 0 || onAttacking.Length > 0;

        public event Action ModifierEnd; // TODO: Implement
        

        public void TimeTick(BaseEntity owner, ModifierData data)
        {
            foreach (var effect in onTimeTick)
            {
                effect.ApplyEffect(owner, data);
            }
        }

        public void UseCard(BaseEntity caster, CardData card, ActionData action, ModifierData data)
        {
            foreach (var effect in onUsingCard)
            {
                effect.CardUsage(caster, card, action, data);
            }
        }

        public void Defend(BaseEntity defender, ActionData action, ModifierData data)
        {
            foreach (var effect in onDefending)
            {
                effect.Defend(defender, action, data);
            }
        }

        public void Attack(BaseEntity defender, ModifierData data)
        {
            foreach (var effect in onAttacking)
            {
                effect.ApplyEffect(defender, data);
            }
        }
    }
}