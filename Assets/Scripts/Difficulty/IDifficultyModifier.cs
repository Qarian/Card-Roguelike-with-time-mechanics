using Encounter;

namespace Difficulty
{
    public interface IDifficultyModifier
    {
        public void ModifyDifficulty(ref float difficulty);

        public void StartEncounter(Combination enemyCombination);
        public void EndEncounter();
    }
}