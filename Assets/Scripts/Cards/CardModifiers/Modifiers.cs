using System.Collections.Generic;
using UI.CardModifiers;
using UI.Entities;
using UnityEngine;

namespace Cards.CardModifiers
{
    public class Modifiers : MonoBehaviour
    {
        [SerializeField] private ModifierIcon modifierIconPrefab;
        
        [Space]
        [SerializeField] private Transform modifiersParent;
        
        private BaseEntity entity;
        private Dictionary<Modifier, AssignedModifier> assignedModifiers;

        public void Initialize(BaseEntity owner)
        {
            entity = owner;
            assignedModifiers = new Dictionary<Modifier, AssignedModifier>();
        }

        public void UseCard(BaseEntity caster, CardData card, ActionData action)
        {
            foreach (KeyValuePair<Modifier,AssignedModifier> assignedModifier in assignedModifiers)
            {
                AssignedModifier value = assignedModifier.Value;
                assignedModifier.Key.UseCard(caster, card, action, value.CurrentData, value.TotalStrength);
            }
        }

        public void Defend(BaseEntity defender, ActionData action)
        {
            foreach (KeyValuePair<Modifier,AssignedModifier> assignedModifier in assignedModifiers)
            {
                AssignedModifier value = assignedModifier.Value;
                assignedModifier.Key.Defend(defender, action, value.CurrentData, value.TotalStrength);
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
            AssignedModifier newAssignedModifier = new AssignedModifier(entity, modData);
            newAssignedModifier.ModifierEnd += () => ModifierEnd(modData.modifier);
            assignedModifiers.Add(modData.modifier, newAssignedModifier);

            if (modData.modifier.useTimer)
            {
                // ToDO: show icon but disable timer
                var icon = Instantiate(modifierIconPrefab, modifiersParent);
                icon.Init(newAssignedModifier, entity);
            }
        }

        private void ModifierEnd(Modifier modifier)
        {
            assignedModifiers.Remove(modifier);
        }
    }
}