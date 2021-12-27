using System.Collections.Generic;
using Character;
using Sirenix.OdinInspector;
using UI.Entities;
using UI.Timeline;
using UnityEngine;

namespace Encounter
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private PossibleEncounters possibleEncounters;

        [SerializeField] private List<Color> colorsForRepeatingEnemies = new();
        
        public EncounterDifficulty difficulty;

        [Space]
        [SceneObjectsOnly]
        [SerializeField] private EntitiesLayoutManager layoutManager;

        [Button]
        public void GenerateEnemies()
        {
            CombinationGroup combinationGroup =
                possibleEncounters.combinationGroup[Random.Range(0, possibleEncounters.combinationGroup.Count)];

            Combination combination = combinationGroup.combinationsPerDifficulties[difficulty];


            List<EnemyEntity> enemies = layoutManager.CreateEnemies(combination);
            
            //Assigning color to multiple same enemies
            Dictionary<EntityData, int> enemyDataCounter = new();

            foreach (EnemyEntity enemyEntity in enemies)
            {
                if (enemyDataCounter.ContainsKey(enemyEntity.entityData))
                    enemyDataCounter[enemyEntity.entityData]++;
                else
                    enemyDataCounter.Add(enemyEntity.entityData, 0);
                
                EntityTimeline.Instance.TrackEntity(enemyEntity, colorsForRepeatingEnemies[enemyDataCounter[enemyEntity.entityData]]);
            }
        }
    }
}
