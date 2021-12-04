using Encounter;
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
        [SerializeField] private EntitiesLayoutManager entities;
        [SerializeField] private UICardsController uiCards;


        private void Start()
        {
            StartEncounter();
        }

        private void StartEncounter()
        {
            player.Initialize();
            uiCards.Init();
            entities.CreateEnemies(EncounterDifficulty.Normal);
        }
    }
}