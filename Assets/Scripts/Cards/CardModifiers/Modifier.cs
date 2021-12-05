using System;
using System.Collections.Generic;
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
        public bool useTimer;

        [Header("Events")]
        [OdinSerialize] private List<ICardUsageEffect> onUsingCard = new ();
        [OdinSerialize] private List<IDefendEffect> onDefending = new ();
        [OdinSerialize] private List<ICharacterEffect> onAttacking = new ();
        [Space]
        [OdinSerialize] private List<ICharacterEffect> onTimeTick = new ();
        
        public bool CanBeAssigned => onTimeTick.Count > 0 || onUsingCard.Count > 0 || onAttacking.Count > 0;

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