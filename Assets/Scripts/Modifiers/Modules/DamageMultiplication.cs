using Card.Actions;
using Entity;

namespace Modifiers.Modules
{
    public class DamageMultiplication : IDamageCalculation
    {
        public float mul = 1;
        
        public void DamageCalculation(CardAttackData attackData, Character context, ModificatorData originData)
        {
            attackData.baseDamage = (int)(attackData.FinalDamage * mul);
        }
    }
}