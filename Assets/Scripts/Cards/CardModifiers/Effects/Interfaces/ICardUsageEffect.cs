using UI.Entities;

namespace Cards.CardModifiers.Effects
{
    public interface ICardUsageEffect
    {
        public void CardUsage(BaseEntity caster, CardData card, ActionData action, ModifierData currentData, int totalStrength);
    }
}