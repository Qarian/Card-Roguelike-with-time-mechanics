using UnityEngine;

namespace Encounter
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private PossibleEncounters possibleEncounters;

        public EncounterDifficulty difficulty;

        private void GenerateEnemies()
        {
            /*CombinationGroup combinationGroup =
                possibleEncounters.combinationGroup[Random.Range(0, possibleEncounters.combinationGroup.Length)];

            Combination c = combinationGroup.combinationsPerDifficulties[difficulty];*/
            //TODO: Generate enemies based on data
        }
    }
}
