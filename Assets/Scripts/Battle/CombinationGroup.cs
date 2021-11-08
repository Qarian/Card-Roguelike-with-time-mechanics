using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(menuName = "Encounters/Combination Group")]
    public class CombinationGroup : SerializedScriptableObject
    {
        [OdinSerialize]
        public Dictionary<BaseDifficulty, Combination> combinationsPerDifficulties;


        CombinationGroup()
        {
            var tmp = new Dictionary<BaseDifficulty ,Combination>();
            foreach (BaseDifficulty difficulty in Enum.GetValues(typeof(BaseDifficulty)))
            {
                tmp.Add(difficulty, new Combination());
            }
            combinationsPerDifficulties = tmp;
        }   
    }
}