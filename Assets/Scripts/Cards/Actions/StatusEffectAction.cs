using Card.Modifiers;
using UI.Entities;
using UnityEngine;

namespace Card.Actions
{
    public class StatusEffectAction : ICardAction
    {
        [SerializeField] private ModificatorScriptable modificator;
        
        public void CreateAttack(CardAttackData data, Character player)
        {
            //data.modificators.Add(modificator, data);
        }
    }
}