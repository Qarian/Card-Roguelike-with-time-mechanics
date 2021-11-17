using System;
using System.Collections.Generic;
using Entity;

namespace Battle
{
    [Serializable]
    public class Combination
    {
        public List<EnemyData> enemies = new ();
    }
}