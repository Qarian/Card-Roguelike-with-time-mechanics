using System;
using System.Collections.Generic;
using Modifiers;

namespace Card.Actions
{
    [Serializable]
    public class CardAttackData
    {
        public Dictionary<Modificator, ModificatorData> modificators = new Dictionary<Modificator, ModificatorData>();

        public float baseDamage = 0;

        // CalculatedOnReceivingSide
        private float finalDamage = 0;

        public float FinalDamage
        {
            get
            {
                return baseDamage + finalDamage;
            }
            set
            {
                finalDamage = value - baseDamage;
            }
        }
    }
}