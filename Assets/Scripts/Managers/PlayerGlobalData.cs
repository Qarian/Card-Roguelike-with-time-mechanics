using Character;

namespace Managers
{
    public static class PlayerGlobalData
    {
        private static PlayerData _current;

        public static PlayerData Current => _current;

        public static void StartNewGame(PlayerDataScriptable playerDataScriptable)
        {
            _current = playerDataScriptable;
        }
    }
}