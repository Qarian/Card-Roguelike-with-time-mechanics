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
        public string name;
        public Sprite icon;
        
        [Space]
        public bool useTimer;

        [Header("Events")]
        [OdinSerialize] private List<IAttackEffect> onAttacking;
        [OdinSerialize] private List<ICardUsageEffect> onUsingCard;
        [OdinSerialize] private List<IDefendEffect> onDefending;
        [OdinSerialize] private List<ICharacterEffect> onTimeTick;

        public Modifier()
        {
            onAttacking = new();
            onUsingCard = new ();
            onDefending = new();
            onTimeTick = new();
        }

        public bool HasEffect(Type effectType)
        {
            return onAttacking.Exists(effect => effect.GetType() == effectType);
        }

        public void TimeTick(BaseEntity owner, ModifierData currentData, int totalStrength)
        {
            foreach (var effect in onTimeTick)
            {
                effect.ApplyEffect(owner, currentData, totalStrength);
            }
        }

        public void UseCard(BaseEntity caster, CardData card, ActionData action, ModifierData currentData, int totalStrength)
        {
            foreach (var effect in onUsingCard)
            {
                effect.CardUsage(caster, card, action, currentData, totalStrength);
            }
        }

        public void Defend(BaseEntity defender, ActionData action, ModifierData currentData, int totalStrength)
        {
            foreach (var effect in onDefending)
            {
                effect.Defend(defender, action, currentData, totalStrength);
            }
        }

        public void Attack(BaseEntity defender, ModifierData currentData)
        {
            foreach (var effect in onAttacking)
            {
                effect.Attack(defender, currentData);
            }
        }
    }
}