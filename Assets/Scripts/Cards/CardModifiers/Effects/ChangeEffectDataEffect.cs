using UI.Entities;
using UnityEngine;

namespace Cards.CardModifiers.Effects
{
    public class ChangeEffectDataEffect : IDefendEffect
    {
        [SerializeField] private IAttackEffect effectToChange;
        [SerializeField] private int difference;
        
        public void Defend(BaseEntity defender, ActionData action, ModifierData currentData, int totalStrength)
        {
            action.ModifyAttackEffect(effectToChange.GetType(),
                data => { data.strength = Mathf.Clamp(data.strength + difference, 0, 9999999); });
        }
    }
}