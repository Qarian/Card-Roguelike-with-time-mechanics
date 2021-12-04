using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UI.Entities;

namespace Encounter
{
    [Serializable]
    public class Combination : IEnumerable<EnemyDataScriptable>
    {
        public List<EnemyDataScriptable> enemies = new ();
        
        public IEnumerator<EnemyDataScriptable> GetEnumerator()
        {
            return enemies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}