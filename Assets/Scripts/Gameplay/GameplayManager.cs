using Encounter;
using Utilities;

namespace Gameplay
{
    public class GameplayManager : Singleton<GameplayManager>
    {
        private void Start()
        {
            StartEncounter();
        }

        private void StartEncounter()
        {
            CombatManager.Instance.StartEncounter();
        }
    }
}