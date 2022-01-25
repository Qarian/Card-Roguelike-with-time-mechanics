using Encounter;
using UnityEngine;

namespace Difficulty
{
    public class TimeDifficultyModifier : IDifficultyModifier
    {
        private const float ExpectedEncounterLength = 25f;
        private const float MinSingleEncounterModifier = 0.8f;
        private const float MaxSingleEncounterModifier = 1.3f;
        private const float MinTotalModifier = 0.9f;
        private const float MaxTotalModifier = 1.2f;
        
        private float currentModifier = 1f;

        private float encounterStartTime;

        public void ModifyDifficulty(ref float difficulty)
        {
            difficulty *= currentModifier;
        }

        public void StartEncounter(Combination enemyCombination)
        {
            encounterStartTime = Time.time;
        }

        public void EndEncounter()
        {
            float duration = Time.time - encounterStartTime;

            float modifierFromDuration = Mathf.Clamp(ExpectedEncounterLength / duration,
                MinSingleEncounterModifier,
                MaxSingleEncounterModifier);
            
            currentModifier = Mathf.Clamp((currentModifier + modifierFromDuration) / 2,
                MinTotalModifier,
                MaxTotalModifier);
        }
    }
}