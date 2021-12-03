using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Cards.CardModifiers
{
    [CreateAssetMenu(fileName = "Modificator", menuName = "Other/Modificator")]
    public class ModificatorScriptable : SerializedScriptableObject
    {
        [OdinSerialize] public Modifier modifier;
        
        public static implicit operator Modifier(ModificatorScriptable m) => m.modifier;
    }
}