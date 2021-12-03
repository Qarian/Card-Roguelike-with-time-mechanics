using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Cards.CardModifiers
{
    [CreateAssetMenu(fileName = "Modificator", menuName = "Other/Modificator")]
    public class ModifierScriptable : SerializedScriptableObject
    {
        [OdinSerialize] public Modifier modifier;
        
        public static implicit operator Modifier(ModifierScriptable m) => m.modifier;
    }
}