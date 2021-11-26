using System;
using UI.Entities;
using UnityEngine;

namespace Card.Modifiers.Modules.Entities
{
    public class CharacterEffectRemoval : ICharacterEffect
    {
        public ModificatorScriptable modificator;
        
        public void Execute(Character target)
        {
            //target.RemoveEffect(modificator);
        }
    }
}