using Sirenix.OdinInspector;
using UnityEngine;

namespace Cards.CardModifiers
{
    [CreateAssetMenu(fileName = "Modifier", menuName = "Other/Modifier")]
    public class ModifierScriptable : SerializedScriptableObject
    {
        public Modifier modifier = new ();
        
        public static implicit operator Modifier(ModifierScriptable m) => m.modifier;
    }
}