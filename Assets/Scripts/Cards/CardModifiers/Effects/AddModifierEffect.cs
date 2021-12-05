using Sirenix.OdinInspector;
using UI.Entities;
using UnityEngine;

namespace Cards.CardModifiers.Effects
{
    [System.Serializable]
    public class AddModifierEffect : ICharacterEffect, ICardUsageEffect
    {
        [SerializeField] private ModifierScriptable modifierToAdd;
        
        [SerializeField] private bool useStrengthFromData = true;
        [HideIf("useStrengthFromData")]
        [SerializeField] private int customStrength;
        
        [SerializeField] private bool useLengthFromData = true;
        [HideIf("useLengthFromData")]
        [SerializeField] private int customLength;
        
        public void ApplyEffect(BaseEntity target, ModifierData data)
        {
            target.Modifiers.ApplyModifier(new ModifierWithData(modifierToAdd, CalculateData(data)));
        }

        public void CardUsage(BaseEntity caster, CardData card, ActionData action, ModifierData data)
        {
            action.modifiersWithData.Add(new ModifierWithData(modifierToAdd, CalculateData(data)));
        }

        private ModifierData CalculateData(ModifierData data)
        {
            int strength = useStrengthFromData ? data.strength : customStrength;
            float length = useLengthFromData ? data.length : customLength;

            return new ModifierData(strength, length);
        }
    }
}