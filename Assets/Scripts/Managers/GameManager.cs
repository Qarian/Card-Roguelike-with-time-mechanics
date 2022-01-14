using Character;
using Encounter;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public static void StartEncounter(PlayerDataScriptable playerDataScriptable)
        {
            PlayerGlobalData.StartNewGame(playerDataScriptable);
            PlayerGlobalData.selectedDifficulty = EncounterDifficulty.Normal;
            SceneManager.LoadScene(1);
        }

        public static void NewEncounter()
        {
            SceneManager.LoadScene(1);
        }

        public void EndEncounter(bool win)
        {
            Debug.Log(win);
            if (win)
            {
                PostCombatManager.Instance.StartEndSequence();
            }
            else
            {
                ReturnToMainMenu();
            }
        }

        private void ReturnToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}