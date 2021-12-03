using Sirenix.Serialization;

namespace Cards.CardModifiers
{
    public class ModifierWithDataScriptable
    {
        [OdinSerialize] private ModifierScriptable modifier;
        [OdinSerialize] private int strength;
        [OdinSerialize] private float length;

        public static implicit operator ModifierWithData(ModifierWithDataScriptable m) =>
            new(m.modifier, new ModifierData(m.strength, m.length));
    }
}