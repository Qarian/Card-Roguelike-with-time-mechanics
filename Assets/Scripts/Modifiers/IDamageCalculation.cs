using Card.Actions;
using Entity;

namespace Modifiers
{
    public interface IDamageCalculation
    {
        public void DamageCalculation(CardAttackData attackData, Character context, ModificatorData originData);
    }
}