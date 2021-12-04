using System;
using System.Collections.Generic;
using Cards.CardModifiers;
using UI.Entities;

namespace Cards
{
    [Serializable]
    public class ActionData
    {
        public List<ModifierWithData> modifiersWithData = new ();

        public void AddModifier(ModifierWithData modData)
        {
            modifiersWithData.Add(modData);
        }
        
        public void AddModifier(Modifier modifier, ModifierData data)
        {
            modifiersWithData.Add(new ModifierWithData(modifier, data));
        }

        public void PerformAction(BaseEntity target)
        {
            target.Defend(this);
            
            foreach (ModifierWithData modData in modifiersWithData)
            {
                modData.modifier.Attack(target, modData.data);
            }
        }
    }
}