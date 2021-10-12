using Other;

namespace Modifiers.Modules
{
    public class DamageAddition : IDamageCalculation
    {
        public float dmg = 0;
        
        public void DamageCalculation(ref float baseDamage, Character context)
        {
            baseDamage += dmg;
        }
    }
}