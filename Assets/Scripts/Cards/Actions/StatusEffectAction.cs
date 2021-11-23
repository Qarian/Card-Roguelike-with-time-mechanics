using Modifiers;
using UI.Entities;
using UnityEngine;

namespace Card.Actions
{
    public class StatusEffectAction : ICardAction
    {
        [SerializeField] private ModificatorScriptable modificator;
        [SerializeField] private ModificatorData values;
        
        public void CreateAttack(CardAttackData data, Character player)
        {
            data.modificators.Add(modificator, values);
        }
    }
}