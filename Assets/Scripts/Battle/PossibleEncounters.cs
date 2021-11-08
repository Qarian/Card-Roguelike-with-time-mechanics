using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(menuName = "Encounters/All")]
    public class PossibleEncounters : ScriptableObject
    {
        public List<CombinationGroup> combinationGroup;
    }
}
