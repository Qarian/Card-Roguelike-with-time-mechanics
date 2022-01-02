using Encounter;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

namespace Gameplay
{
    public class GameplayManager : Singleton<GameplayManager>
    {
        private void StartEncounter()
        {
            SceneManager.LoadScene(1);
            CombatManager.Instance.StartEncounter();
        }

        public void EndEncounter(bool win)
        {
            Debug.Log(win);
            ReturnToMainMenu();
        }

        private void ReturnToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}