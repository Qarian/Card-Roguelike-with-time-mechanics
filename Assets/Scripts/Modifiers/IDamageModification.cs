using Other;

namespace Modifiers
{
    public interface IDamageCalculation
    {
        public void DamageCalculation(ref float baseDamage, Character context);
    }
}