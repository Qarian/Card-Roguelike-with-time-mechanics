using System.Collections.Generic;
using Character;
using Difficulty;
using Encounter;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Zenject;

namespace UI.Entities
{
    public class EntitiesLayoutManager : MonoBehaviour
    {
        [SerializeField] private LayoutGroup enemiesLayout;

        private EnemyEntity.Factory enemyFactory;

        private List<EnemyEntity> createdEnemies = new();

        [Inject]
        private void Init(EnemyEntity.Factory enemyFactory)
        {
            this.enemyFactory = enemyFactory;
        }
        
        public List<EnemyEntity> CreateEnemies(Combination enemiesCombination)
        {
            ClearEnemies();
            foreach (EnemyDataScriptable data in enemiesCombination)
            {
                EnemyEntity entity = enemyFactory.Create();
                entity.transform.SetParent(enemiesLayout.transform, false);
                entity.Init(data, DifficultyScaler.GetDifficulty(enemiesCombination.baseDifficulty));
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
