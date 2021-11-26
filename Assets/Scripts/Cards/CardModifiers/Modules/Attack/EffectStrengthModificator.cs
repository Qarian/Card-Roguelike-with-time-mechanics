using Card.Actions;
using UI.Entities;

namespace Card.Modifiers.Modules
{
    public class EffectStrengthModificator : IDamageCalculation
    {
        public ModificatorScriptable modificatorScriptable;
        public float multiplication = 1;
        public bool useAddition;
        public bool clearEffect;

        private Modifier Modifier => modificatorScriptable.modifier;
        
        public void DamageCalculation(CardAttackData attackData, Character context)
        {
            //float modification = context.mods.str * multiplication;
            /*if (useAddition)
                attackData.FinalDamage += modification;
            else
                attackData.FinalDamage *= modification;*/
            
            //if (clearEffect)
                //context.RemoveEffect(Modifier);
        }
    }
}