using Card.Actions;
using UI.Entities;

namespace Modifiers.Modules
{
    public class EffectStrengthModificator : IDamageCalculation
    {
        public ModificatorScriptable modificatorScriptable;
        public float multiplication = 1;
        public bool useAddition;
        public bool clearEffect;

        private Modificator Modificator => modificatorScriptable.modificator;
        
        public void DamageCalculation(CardAttackData attackData, Character context, ModificatorData originData)
        {
            float modification = context.GetEffectData(Modificator).strength * multiplication;
            if (useAddition)
                attackData.FinalDamage += modification;
            else
                attackData.FinalDamage *= modification;
            
            if (clearEffect)
                context.RemoveEffect(Modificator);
        }
    }
}