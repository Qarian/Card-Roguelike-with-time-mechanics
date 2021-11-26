using System.Collections.Generic;
using Card.Actions;
using Card.Modifiers;
using UnityEngine;

namespace UI.Entities
{
    [CreateAssetMenu(menuName = "Characters/Blank Character")]
    public class Character : ScriptableObject
    {
        [SerializeField] private int life = 100;

        private Modifiers modifiers = new Modifiers();

        public void ApplyAction(CardAttackData attackData)
        {
            /*foreach (Modifier modificator in appliedEffects.Keys)
            {
                modificator.CalculateDamageReceived(attackData, this, appliedEffects[modificator]);
            }*/

            life -= (int)attackData.FinalDamage;
        }
    }
}