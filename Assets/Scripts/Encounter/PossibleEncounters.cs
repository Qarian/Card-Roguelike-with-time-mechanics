using System.Collections.Generic;
using UnityEngine;

namespace Encounter
{
    [CreateAssetMenu(menuName = "Encounters/All")]
    public class PossibleEncounters : ScriptableObject
    {
        public List<CombinationGroup> combinationGroup = new();

        public int Count => combinationGroup.Count;

        public CombinationGroup this[int i] => combinationGroup[i];
    }
}
