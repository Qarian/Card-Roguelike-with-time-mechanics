using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Cards.CardModifiers
{
    [CreateAssetMenu(fileName = "Modifier", menuName = "Other/Modifier")]
    public class ModifierScriptable : SerializedScriptableObject
    {
        [OdinSerialize] public Modifier modifier = new ();
        
        public static implicit operator Modifier(ModifierScriptable m) => m.modifier;
    }
}