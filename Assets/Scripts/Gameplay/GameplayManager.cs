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
        [SerializeField] private BattleManager battleManager;
        [SerializeField] private UICardsController uiCards;


        private void Start()
        {
            StartEncounter();
        }

        private void StartEncounter()
        {
            player.Initialize();
            uiCards.Init();
            battleManager.GenerateEnemies();
            //ToDo: unpause after first move
            TimeManager.Paused = false;
        }

        public void EndEncounter(bool playerWon)
        {
            
        }
    }
}