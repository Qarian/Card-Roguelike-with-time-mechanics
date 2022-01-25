using System;
using System.Collections.Generic;
using Cards.CardModifiers;
using UI.Entities;

namespace Cards
{
    public class ActionData
    {
        public List<ModifierWithData> modifiersWithData = new ();

        public void AddModifier(ModifierWithData modData)
        {
            modifiersWithData.Add(modData);
        }

        public void PerformAction(BaseEntity target)
        {
            target.Defend(this);
            
            foreach (ModifierWithData modData in modifiersWithData)
            {
                modData.modifier.Attack(target, modData.data);
            }
        }
        
        public void ModifyAttackEffect(Type affectedEffect, Action<ModifierData> action)
        {
            foreach (ModifierWithData modWithData in modifiersWithData)
            {
                if (modWithData.modifier.HasEffect(affectedEffect))
                {
                    action.Invoke(modWithData.data);
                }
            }
        }
    }
}