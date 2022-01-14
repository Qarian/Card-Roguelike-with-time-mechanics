using Character;
using Encounter;

namespace Managers
{
    public static class PlayerGlobalData
    {
        public static EncounterDifficulty selectedDifficulty;
        
        private static PlayerData _current;

        public static PlayerData Current => _current;

        public static void StartNewGame(PlayerDataScriptable playerDataScriptable)
        {
            _current = playerDataScriptable;
        }
    }
}