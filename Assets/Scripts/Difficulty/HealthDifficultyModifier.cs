using Encounter;
using Managers;
using UnityEngine;

namespace Difficulty
{
    public class HealthDifficultyModifier : IDifficultyModifier
    {
        // Clamps for modifier based on player health post combat
        private const float MinHealthModifier = 0.7f;
        private const float MaxHealthModifier = 1f;
        
        // Add const value every time player end combat with perfect health
        private const float PerfectHealthModifier = 0.08f;

        private int currentPerfectHealthStack = 0;
        private float currentHealthModifier = MaxHealthModifier;
        
        public void ModifyDifficulty(ref float difficulty)
        {
            difficulty *= currentHealthModifier;
            difficulty += currentPerfectHealthStack * PerfectHealthModifier;
        }

        public void StartEncounter(Combination enemyCombination)
        {
            throw new System.NotImplementedException();
        }

        public void EndEncounter()
        {
            float healthPercent = PlayerGlobalData.Current.currentHealth / (float) PlayerGlobalData.Current.maxHealth;
            currentHealthModifier = Mathf.Clamp(healthPercent, MinHealthModifier, MaxHealthModifier);
            
            if (Mathf.Approximately(healthPercent, 1f))
                currentPerfectHealthStack++;
        }
    }
}