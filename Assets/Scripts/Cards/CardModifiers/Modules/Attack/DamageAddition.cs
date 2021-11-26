using Card.Actions;
using UI.Entities;

namespace Card.Modifiers.Modules
{
    public class DamageAddition : IDamageCalculation
    {
        public float dmg = 0;

        public void DamageCalculation(CardAttackData attackData, Character context)
        {
            attackData.FinalDamage += dmg;
        }
    }
}