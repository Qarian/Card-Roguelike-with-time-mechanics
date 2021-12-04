using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Characters/Enemy")]
    public class EnemyDataScriptable : ScriptableObject
    {
        [SerializeField] private EnemyData data;

        public static implicit operator EnemyData(EnemyDataScriptable e) => new (e.data);
    }
}