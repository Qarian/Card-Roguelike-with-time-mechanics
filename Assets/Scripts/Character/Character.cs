using System.Collections.Generic;
using Card.Actions;
using Modifiers;
using UnityEngine;

namespace UI.Entities
{
    [CreateAssetMenu(menuName = "Characters/Blank Character")]
    public class Character : ScriptableObject
    {
        [SerializeField] private int life = 100;
        
        private Dictionary<Modificator, ModificatorData> appliedEffects = new Dictionary<Modificator, ModificatorData>();

        public void ApplyAction(CardAttackData attackData)
        {
            foreach (Modificator modificator in appliedEffects.Keys)
            {
                modificator.CalculateDamageReceived(attackData, this, appliedEffects[modificator]);
            }

            life -= (int)attackData.FinalDamage;
        }

        public void ApplyEffect(Modificator modificator, ModificatorData data)
        {
            if (appliedEffects.ContainsKey(modificator))
            {
                appliedEffects[modificator].Modify(data);
            }
            else
            {
                appliedEffects.Add(modificator, data);
            }
        }

        public ModificatorData GetEffectData(Modificator modificator)
        {
            if (appliedEffects.ContainsKey(modificator))
                return appliedEffects[modificator];
            else
                return ModificatorData.Empty;
        }

        public void RemoveEffect(Modificator modificator)
        {
            if (appliedEffects.ContainsKey(modificator))
                appliedEffects.Remove(modificator);
        }
    }
}