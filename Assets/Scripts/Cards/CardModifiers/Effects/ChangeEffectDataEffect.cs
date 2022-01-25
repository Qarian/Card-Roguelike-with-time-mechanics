using Sirenix.OdinInspector;
using UI.Entities;
using UnityEngine;

namespace Cards.CardModifiers.Effects
{
    public class ChangeEffectDataEffect : IDefendEffect, ICardUsageEffect
    {
        [SerializeField] private IAttackEffect effectToChange;
        [SerializeField] private bool useDifferenceFromStrength = true;
        [HideIf("useDifferenceFromStrength")]
        [SerializeField] private int customDifference;
        [SerializeField] private bool clampNegative = true;

        public void Defend(BaseEntity defender, ActionData action, ModifierData currentData, int totalStrength)
        {
            action.ModifyAttackEffect(effectToChange.GetType(),
                data => { data.strength = ChangedValue(data.strength, totalStrength); });
        }

        public void CardUsage(BaseEntity caster, CardData card, ActionData action, ModifierData currentData, int totalStrength)
        {
            action.ModifyAttackEffect(effectToChange.GetType(),
                data => { data.strength = ChangedValue(data.strength, totalStrength); });
        }

        private int ChangedValue(in int baseValue, int modifierStrength)
        {
            int difference = useDifferenceFromStrength ? modifierStrength : customDifference;
            int changedValue = baseValue + difference;
            return clampNegative ? Mathf.Clamp(changedValue, 0, int.MaxValue) : changedValue;
        }
    }
}