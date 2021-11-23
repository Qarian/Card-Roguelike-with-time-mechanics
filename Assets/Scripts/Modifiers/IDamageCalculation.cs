using Card.Actions;
using UI.Entities;

namespace Modifiers
{
    public interface IDamageCalculation
    {
        public void DamageCalculation(CardAttackData attackData, Character context, ModificatorData originData);
    }
}