using Card.Actions;
using UI.Entities;

namespace Card.Modifiers
{
    public interface IDamageCalculation
    {
        public void DamageCalculation(CardAttackData attackData, Character context);
    }
}