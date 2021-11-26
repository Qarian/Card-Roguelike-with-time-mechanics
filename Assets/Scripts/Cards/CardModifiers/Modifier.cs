using System;
using Card.Actions;
using Card.Modifiers.Modules;
using UI.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Card.Modifiers
{
    public class Modifier
    {
        [Space]
        [Required]
        public string name;

        public ModifierStacking stacking = ModifierStacking.None;
        public float Strength { get; private set; }
        public bool UseTimer => onTimeTick.Length > 0;

        [Space]
        public IDamageCalculation[] onDamageReceived;
        public ISelfEffect[] onTimeTick;

        public void CalculateDamageReceived(CardAttackData attackData, Character target)
        {
            foreach (var t in onDamageReceived)
            {
                t.DamageCalculation(attackData, target);
            }
        }

        public void Modify(Modifier another)
        {
            switch (stacking)
            {
                case ModifierStacking.None:
                    break;
                case ModifierStacking.Add:
                    Strength += another.Strength;
                    break;
                case ModifierStacking.Max:
                    Strength = Mathf.Max(Strength, another.Strength);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    public enum ModifierStacking
    {
        None,
        Add,
        Max
    }
}