using Card.Modifiers.Modules;
using Cards.CardModifiers.Modules;
using Sirenix.OdinInspector;
using UI.Entities;
using UnityEngine;

namespace Cards.CardModifiers
{
    public class Modifier
    {
        [Space]
        [Required]
        public string name;
        
        public bool UseTimer => onTimeTick.Length > 0;

        [Space]
        public IDamageCalculation[] onDamageReceived;
        public ISelfEffect[] onTimeTick;

        public void TimeTick(BaseEntity owner, ModifierData data)
        {
            foreach (ISelfEffect effect in onTimeTick)
            {
                effect.Execute(owner, data);
            }
        }

        public void CalculateDamageReceived(CardAttackData attackData, EntityData target)
        {
            foreach (var t in onDamageReceived)
            {
                //t.DamageCalculation(attackData, target);
            }
        }
    }
}