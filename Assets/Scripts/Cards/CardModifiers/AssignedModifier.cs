using System;
using System.Collections.Generic;
using Timing;
using UI.Entities;

namespace Cards.CardModifiers
{
    public class AssignedModifier
    {
        private readonly Modifier modifier;
        private readonly BaseEntity entityData;
        
        public readonly List<ModifierData> allData = new ();
        public ModifierData CurrentData => allData[0];

        public readonly List<Timer> allTimers = new ();
        public Timer CurrentTimer => allTimers[0];

        public event Action<ModifierData> NewData;
        public event Action TimeTick;
        public event Action ModifierEnd;


        public AssignedModifier(BaseEntity entityData, ModifierWithData modData)
        {
            this.entityData = entityData;
            modifier = modData.modifier;
            
            AddNew(modData);
            CurrentTimer.StartAutoUpdate();
        }
        
        public void AddNew(ModifierWithData modData)
        {
            AddNew(modData.data);
        }
        
        private void AddNew(ModifierData newModifierData)
        {
            allData.Add(newModifierData);
            if (modifier.UseTimer)
            {
                allTimers.Add(new Timer(newModifierData.length, OnTimeOut));
            }
            NewData?.Invoke(newModifierData);
        }

        private void OnTimeOut()
        {
            modifier.TimeTick(entityData, CurrentData);
            if (allData.Count > 1)
            {
                TimeTick?.Invoke();
                
                allData.RemoveAt(0);
                allTimers.RemoveAt(0);
                CurrentTimer.StartAutoUpdate();
            }
            else
            {
                ModifierEnd?.Invoke();
            }
        }
    }
}