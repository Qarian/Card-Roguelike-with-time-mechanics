using Card.Actions;
using UI.Entities;

namespace Card.Modifiers.Modules
{
    public class DamageMultiplication : IDamageCalculation
    {
        public float mul = 1;
        
        public void DamageCalculation(CardAttackData attackData, Character context)
        {
            attackData.baseDamage = (int)(attackData.FinalDamage * mul);
        }
    }
}