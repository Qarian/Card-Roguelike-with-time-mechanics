using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Characters/Player")]
    public class PlayerDataScriptable : ScriptableObject
    {
        public PlayerData data;

        public static implicit operator PlayerData(PlayerDataScriptable e) => e.data;
    }
}