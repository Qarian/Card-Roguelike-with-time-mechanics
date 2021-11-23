using Card.Actions;
using UI.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modifiers
{
    public class Modificator
    {
        [Space]
        [Required]
        public string name;

        [Space]
        public IDamageCalculation[] onTurnStart;
        public IDamageCalculation[] onTurnEnd;
        public IDamageCalculation[] onDamageReceived;

        public void CalculateDamageReceived(CardAttackData attackData, Character target, ModificatorData modificatorData)
        {
            foreach (var t in onDamageReceived)
            {
                t.DamageCalculation(attackData, target, modificatorData);
            }
        }
    }
}