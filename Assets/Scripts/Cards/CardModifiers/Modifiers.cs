using System.Collections.Generic;
using UI.Entities;
using UnityEngine;

namespace Cards.CardModifiers
{
    public class Modifiers : MonoBehaviour
    {
        private BaseEntity entityData;
        private Dictionary<Modifier, AssignedModifier> assignedModifiers = new ();

        public void Initialize(BaseEntity owner)
        {
            entityData = owner;
        }

        public void ApplyModifier(ModifierWithData modData)
        {
            if (!assignedModifiers.ContainsKey(modData.modifier))
            {
                AssignedModifier newAssignedModifier = new AssignedModifier(entityData, modData);
                newAssignedModifier.ModifierEnd += () => OnModifierEnd(modData);
                assignedModifiers.Add(modData.modifier, newAssignedModifier);
            }
            else
            {
                assignedModifiers[modData.modifier].AddNew(modData);
            }
        }

        private void OnModifierEnd(ModifierWithData modData)
        {
            assignedModifiers.Remove(modData.modifier);
        }
    }
}