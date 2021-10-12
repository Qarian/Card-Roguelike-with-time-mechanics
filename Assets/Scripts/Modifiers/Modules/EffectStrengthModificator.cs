using Other;

namespace Modifiers.Modules
{
    public class EffectStrengthModificator : IDamageCalculation
    {
        public ModificatorScriptable modificatorScriptable;
        public float multiplication = 1;
        public bool useAddition;
        public bool clearEffect;

        private Modificator Modificator => modificatorScriptable.modificator;
        
        public void DamageCalculation(ref float baseDamage, Character context)
        {
            float modification = context.GetEffectData(Modificator).strength * multiplication;
            if (useAddition)
                baseDamage += modification;
            else
                baseDamage *= modification;
            
            if (clearEffect)
                context.RemoveEffect(Modificator);
        }
    }
}