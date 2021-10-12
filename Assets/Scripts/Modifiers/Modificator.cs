using Sirenix.OdinInspector;
using UnityEngine;

namespace Modifiers
{
    public class Modificator
    {
        [Space]
        [Required]
        public string name;

        [Space]
        public IDamageCalculation[] onTurnStart;
        public IDamageCalculation[] onTurnEnd;
        public IDamageCalculation[] onDamageReceived;
    }
}