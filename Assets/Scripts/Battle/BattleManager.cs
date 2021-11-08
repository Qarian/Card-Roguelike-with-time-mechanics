using UnityEngine;

namespace Battle
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private PossibleEncounters possibleEncounters;

        public BaseDifficulty difficulty;

        private void GenerateEnemies()
        {
            /*CombinationGroup combinationGroup =
                possibleEncounters.combinationGroup[Random.Range(0, possibleEncounters.combinationGroup.Length)];

            Combination c = combinationGroup.combinationsPerDifficulties[difficulty];*/
            //TODO: Generate enemies based on data
        }
    }
}
