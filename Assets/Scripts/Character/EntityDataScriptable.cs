using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Characters/Blank Character")]
    public class EntityDataScriptable : ScriptableObject
    {
        [SerializeField] private EntityData data;

        public static implicit operator EntityData(EntityDataScriptable e) => new(e.data);
    }
}