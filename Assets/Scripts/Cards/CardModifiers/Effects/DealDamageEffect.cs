using UI.Entities;

namespace Cards.CardModifiers.Effects
{
    public class DealDamageEffect : ICharacterEffect
    {
        public void ApplyEffect(BaseEntity target, ModifierData data)
        {
            target.ModifyHealth(-data.strength);
        }
    }
}