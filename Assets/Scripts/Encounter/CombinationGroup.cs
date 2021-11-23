using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Encounter
{
    [CreateAssetMenu(menuName = "Encounters/Combination Group")]
    public class CombinationGroup : SerializedScriptableObject
    {
        [OdinSerialize]
        public Dictionary<EncounterDifficulty, Combination> combinationsPerDifficulties;

        CombinationGroup()
        {
            var tmp = new Dictionary<EncounterDifficulty ,Combination>();
            foreach (EncounterDifficulty difficulty in Enum.GetValues(typeof(EncounterDifficulty)))
            {
                tmp.Add(difficulty, new Combination());
            }
            combinationsPerDifficulties = tmp;
        }

        public Combination GetCombination(EncounterDifficulty difficulty) => combinationsPerDifficulties[difficulty];
    }
}