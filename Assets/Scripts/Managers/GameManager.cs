using Character;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private PlayerDataScriptable playerDataScriptable;
        
        public static void StartEncounter()
        {
            PlayerGlobalData.StartNewGame(Instance.playerDataScriptable);
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