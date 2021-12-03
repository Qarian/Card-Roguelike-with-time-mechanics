using UI.Entities;

namespace Cards.CardModifiers.Modules
{
    public interface IDamageCalculation
    {
        public void DamageCalculation(CardAttackData attackData, EntityData context);
    }
}