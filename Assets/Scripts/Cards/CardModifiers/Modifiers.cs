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

        public void UseCard(BaseEntity caster, CardData card, ActionData action)
        {
            foreach (KeyValuePair<Modifier,AssignedModifier> assignedModifier in assignedModifiers)
            {
                assignedModifier.Key.UseCard(caster, card, action, assignedModifier.Value.CurrentData);
            }
        }

        public void Defend(BaseEntity defender, ActionData action)
        {
            foreach (KeyValuePair<Modifier,AssignedModifier> assignedModifier in assignedModifiers)
            {
                assignedModifier.Key.Defend(defender, action, assignedModifier.Value.CurrentData);
            }
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