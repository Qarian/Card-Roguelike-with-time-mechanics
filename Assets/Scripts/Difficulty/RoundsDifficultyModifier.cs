using Encounter;

namespace Difficulty
{
    public class RoundsDifficultyModifier : IDifficultyModifier
    {
        private const float PerRoundModifier = 0.1f;

        private int roundCount = 0;
        
        public void ModifyDifficulty(ref float difficulty)
        {
            difficulty += roundCount * PerRoundModifier;
        }

        public void StartEncounter(Combination enemyCombination)
        {
            
        }

        public void EndEncounter()
        {
            roundCount++;
        }
    }
}