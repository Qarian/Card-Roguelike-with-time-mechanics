using System;
using System.Collections.Generic;
using System.Linq;
using Encounter;

namespace Managers
{
    public class PlaythroughStats
    {
        public Dictionary<EncounterDifficulty, int> difficultyCounter;

        public int WonEncounters => difficultyCounter.Values.Sum() - 1;

        public PlaythroughStats()
        {
            difficultyCounter = new();
            foreach (EncounterDifficulty difficulty in Enum.GetValues(typeof(EncounterDifficulty)))
            {
                difficultyCounter.Add(difficulty, 0);
            }
        }

        public void NewEncounter()
        {
            difficultyCounter[PlayerGlobalData.selectedDifficulty]++;
        }
    }
}