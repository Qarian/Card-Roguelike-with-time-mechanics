using Other;

namespace Modifiers.Modules
{
    public class DamageMultiplication : IDamageCalculation
    {
        public float mul = 1;
        
        public void DamageCalculation(ref float baseDamage, Character context)
        {
            baseDamage *= mul;
        }
    }
}