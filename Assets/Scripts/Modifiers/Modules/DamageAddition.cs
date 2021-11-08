﻿using Card.Actions;
using Entity;

namespace Modifiers.Modules
{
    public class DamageAddition : IDamageCalculation
    {
        public float dmg = 0;

        public void DamageCalculation(CardAttackData attackData, Character context, ModificatorData originData)
        {
            attackData.FinalDamage += dmg;
        }
    }
}