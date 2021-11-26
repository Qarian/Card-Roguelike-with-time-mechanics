using System;
using System.Collections.Generic;
using Card.Modifiers;

namespace Card.Actions
{
    [Serializable]
    public class CardAttackData
    {
        public List<Modifier> modificators = new List<Modifier>();

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