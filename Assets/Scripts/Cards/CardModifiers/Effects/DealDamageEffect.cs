using UI.Entities;

namespace Cards.CardModifiers.Effects
{
    public class DealDamageEffect : ICharacterEffect, IAttackEffect
    {
        public void ApplyEffect(BaseEntity target, ModifierData currentData, int totalStrength)
        {
            target.ModifyHealth(-totalStrength);
        }

        public void Attack(BaseEntity target, ModifierData currentData)
        {
            target.ModifyHealth(-currentData.strength);
        }
    }
}