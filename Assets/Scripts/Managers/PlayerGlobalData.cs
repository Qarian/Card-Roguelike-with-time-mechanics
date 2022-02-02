using Character;
using Encounter;

namespace Managers
{
    public static class PlayerGlobalData
    {
        public static EncounterDifficulty selectedDifficulty;
        
        private static PlayerData _current;
        private static PlaythroughStats _stats;

        public static PlayerData Current => _current;
        public static PlaythroughStats Stats => _stats;

        public static void StartNewGame(PlayerDataScriptable playerDataScriptable)
        {
            _current = playerDataScriptable;
            _stats = new PlaythroughStats();
        }
    }
}