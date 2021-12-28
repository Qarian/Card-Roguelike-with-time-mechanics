using Encounter;
using Timing;
using UI.Cards;
using UI.Entities;
using UnityEngine;
using Utilities;

namespace Gameplay
{
    public class GameplayManager : Singleton<GameplayManager>
    {
        [Space]
        [SerializeField] private PlayerEntity player;
        [SerializeField] private CombatManager combatManager;
        [SerializeField] private UICardsController uiCards;

        private void Start()
        {
            StartEncounter();
        }

        private void StartEncounter()
        {
            player.Initialize();
            combatManager.GenerateEnemies();
            uiCards.Init();

            combatManager.EnablePlayerActions();
            TimeManager.Paused = true;
        }
    }
}