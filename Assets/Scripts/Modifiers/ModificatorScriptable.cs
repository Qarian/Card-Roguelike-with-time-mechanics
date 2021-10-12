using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Modifiers
{
    [CreateAssetMenu(fileName = "Modificator", menuName = "Other/Modificator")]
    public class ModificatorScriptable : SerializedScriptableObject
    {
        [OdinSerialize] public Modificator modificator;
    }
}