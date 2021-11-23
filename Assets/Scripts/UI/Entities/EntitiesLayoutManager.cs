using System.Collections.Generic;
using Encounter;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Entities
{
    public class EntitiesLayoutManager : MonoBehaviour
    {
        [SerializeField] private PossibleEncounters possibleEncounters; // possible assignment from code
        [SerializeField] private EnemyEntity enemyPrefab;

        [Space]
        [SerializeField] private LayoutGroup enemiesLayout;

        private List<EnemyEntity> createdEnemies = new();
        
        [Button]
        public void CreateEnemies(EncounterDifficulty difficulty)
        {
            if (possibleEncounters.Count == 0) return;
            
            ClearEnemies();
            int chosenEncounter = Random.Range(0, possibleEncounters.Count);
            var enemies = possibleEncounters[chosenEncounter].GetCombination(difficulty);
            foreach (EnemyData data in enemies)
            {
                EnemyEntity entity = Instantiate(enemyPrefab, enemiesLayout.transform);
                entity.Init(data);
                createdEnemies.Add(entity);
            }
        }

        [Button]
        private void ClearEnemies()
        {
            foreach (EnemyEntity enemy in createdEnemies)
            {
#if UNITY_EDITOR
                DestroyImmediate(enemy.gameObject);
#else
                Destroy(enemy);
#endif
            }
            createdEnemies.Clear();
        }
    }
}
