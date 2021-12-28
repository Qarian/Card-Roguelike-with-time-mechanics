using System;
using System.Collections.Generic;
using Timing;
using UI.Entities;

namespace Cards.CardModifiers
{
    public class AssignedModifier
    {
        private readonly Modifier modifier;
        public Modifier Modifier => modifier;
        
        private readonly BaseEntity entityData;
        
        public readonly List<ModifierData> allData = new ();
        public ModifierData CurrentData => allData[0];

        public readonly List<Timer> allTimers = new ();
        public Timer CurrentTimer => allTimers[0];

        public event Action<ModifierData> NewData;
        public event Action TimeTick;
        public event Action ModifierEnd;
        
        public int TotalStrength
        {
            get
            {
                int strengthSum = 0;
                foreach (ModifierData data in allData)
                {
                    strengthSum += data.strength;
                }
                return strengthSum;
            }
        }


        public AssignedModifier(BaseEntity entityData, ModifierWithData modData)
        {
            this.entityData = entityData;
            modifier = modData.modifier;
            
            AddNew(modData);
            CurrentTimer.Start();
        }
        
        public void AddNew(ModifierWithData modData)
        {
            AddNew(modData.data);
        }
        
        private void AddNew(ModifierData newModifierData)
        {
            allData.Add(newModifierData);
            if (modifier.useTimer)
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
                allData.RemoveAt(0);
                allTimers.RemoveAt(0);
                CurrentTimer.Start();
                
                TimeTick?.Invoke();
            }
            else
            {
                ModifierEnd?.Invoke();
            }
        }
    }
}