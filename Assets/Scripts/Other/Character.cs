using System.Collections.Generic;
using Modifiers;

namespace Other
{
    public class Character
    {
        private Dictionary<Modificator, ModificatorData> appliedEffects = new Dictionary<Modificator, ModificatorData>();

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