using System.Collections.Generic;
using Encounter;

namespace Difficulty
{
    public static class DifficultyScaler
    {
        public static List<IDifficultyModifier> modifiers = new();
        
        public static float GetDifficulty(float baseDifficulty = 1f)
        {
            foreach (IDifficultyModifier difficultyModifier in modifiers)
            {
                difficultyModifier.ModifyDifficulty(ref baseDifficulty);
            }

            return baseDifficulty;
        }

        public static void StartGameplay()
        {
            modifiers.Clear();
            
            modifiers.Add(new TimeDifficultyModifier());
            modifiers.Add(new HealthDifficultyModifier());
            modifiers.Add(new RoundsDifficultyModifier());
            modifiers.Add(new PlayerSuggestionDifficultyModifier());
        }

        public static void NewEncounter(Combination enemyCombination)
        {
            foreach (IDifficultyModifier difficultyModifier in modifiers)
            {
                difficultyModifier.StartEncounter(enemyCombination);
            }
        }

        public static void EndEncounter()
        {
            foreach (IDifficultyModifier difficultyModifier in modifiers)
            {
                difficultyModifier.EndEncounter();
            }
        }
    }
}