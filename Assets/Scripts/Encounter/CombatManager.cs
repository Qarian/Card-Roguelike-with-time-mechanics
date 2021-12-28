using System;
using System.Collections.Generic;
using Character;
using Sirenix.OdinInspector;
using Timing;
using UI.Entities;
using UI.Timeline;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Encounter
{
    public class CombatManager : Singleton<CombatManager>
    {
        [SerializeField] private PossibleEncounters possibleEncounters;

        [SerializeField] private List<Color> colorsForRepeatingEnemies = new();
        
        public EncounterDifficulty difficulty;

        [Space]
        [SceneObjectsOnly]
        [SerializeField] private EntitiesLayoutManager layoutManager;
        

        private List<EnemyEntity> enemies;
        private CombatState state;

        private bool playerActionsEnabled;

        public bool PlayerActionsEnabled => playerActionsEnabled;
        public event Action<bool> OnPlayerActionsChange;

        [Button]
        public void GenerateEnemies()
        {
            CombinationGroup combinationGroup =
                possibleEncounters.combinationGroup[Random.Range(0, possibleEncounters.combinationGroup.Count)];

            Combination combination = combinationGroup.combinationsPerDifficulties[difficulty];


            enemies = layoutManager.CreateEnemies(combination);
            
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

        public void StartCombat()
        {
            foreach (EnemyEntity enemy in enemies)
            {
                enemy.StartCombat();
            }
        }
        
        public void EndCombat()
        {
            state = CombatState.Finish;
        }
        
        public void ActionPerformed()
        {
            if (state == CombatState.Start)
            {
                state = CombatState.Combat;
                StartCombat();
                TimeManager.Paused = false;
            }

            playerActionsEnabled = false;
            OnPlayerActionsChange?.Invoke(false);
        }

        public void EnablePlayerActions()
        {
            playerActionsEnabled = true;
            OnPlayerActionsChange?.Invoke(true);
        }

        private enum CombatState
        {
            Start, Combat, Finish
        }
    }
}
