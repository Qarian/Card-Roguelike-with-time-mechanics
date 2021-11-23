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
            return new CombinationEnumerator(enemies);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private class CombinationEnumerator : IEnumerator<EnemyData>
        {
            private readonly IList<EnemyData> enemies;
            private int currentId;

            public CombinationEnumerator(IList<EnemyData> enemies)
            {
                this.enemies = enemies;
                currentId = -1;
            }
            
            public bool MoveNext()
            {
                currentId++;
                return enemies.Count > currentId;
            }

            public void Reset()
            {
                currentId = -1;
            }

            public EnemyData Current => enemies[currentId];
            object IEnumerator.Current => Current;

            public void Dispose() { }
        }
    }
}