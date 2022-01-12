using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Characters/Player")]
    public class PlayerDataScriptable : ScriptableObject
    {
        [SerializeField] private PlayerData data;

        public static implicit operator PlayerData(PlayerDataScriptable e) => new (e.data);
    }
}