using System;
using System.Collections;
using System.Collections.Generic;
using UI.Entities;

namespace Encounter
{
    [Serializable]
    public class Combination : IEnumerable<EnemyData>
    {
        public List<EnemyData> enemies = new ();
        
        public IEnumerator<EnemyData> GetEnumerator()
        {
            return enemies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}