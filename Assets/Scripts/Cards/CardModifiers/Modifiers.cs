using System.Collections.Generic;
using UI.Entities;
using UnityEngine;

namespace Cards.CardModifiers
{
    public class Modifiers : MonoBehaviour
    {
        private BaseEntity entityData;
        private Dictionary<Modifier, AssignedModifier> assignedModifiers;

        public void Initialize(BaseEntity owner)
        {
            entityData = owner;
            assignedModifiers = new Dictionary<Modifier, AssignedModifier>();
        }

        public void ApplyModifier(ModifierWithData modData)
        {
            if (!assignedModifiers.ContainsKey(modData.modifier))
            {
                CreateNewModifier(modData);
            }
            else
            {
                assignedModifiers[modData.modifier].AddNew(modData);
            }
        }

        private void CreateNewModifier(ModifierWithData modData)
        {
            AssignedModifier newAssignedModifier = new AssignedModifier(entityData, modData);
            newAssignedModifier.ModifierEnd += () => ModifierEnd(modData.modifier);
            assignedModifiers.Add(modData.modifier, newAssignedModifier);
        }

        private void ModifierEnd(Modifier modifier)
        {
            assignedModifiers.Remove(modifier);
        }
    }
}