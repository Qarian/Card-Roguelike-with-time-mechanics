using System.Collections.Generic;
using Character;
using Encounter;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI.Entities
{
    public class EntitiesLayoutManager : Singleton<EntitiesLayoutManager>
    {
        [SerializeField] private PossibleEncounters possibleEncounters; // possible assignment from code
        [SerializeField] private EnemyEntity enemyPrefab;

        [Space]
        [SerializeField] private LayoutGroup enemiesLayout;

        private List<EnemyEntity> createdEnemies = new();
        
        public List<EnemyEntity> CreateEnemies(Combination enemiesCombination)
        {
            ClearEnemies();
            foreach (EnemyDataScriptable data in enemiesCombination)
            {
                EnemyEntity entity = Instantiate(enemyPrefab, enemiesLayout.transform);
                entity.Init(data);
                createdEnemies.Add(entity);
            }

            return createdEnemies;
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
