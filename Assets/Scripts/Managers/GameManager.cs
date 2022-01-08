using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Gameplay
{
    public class GameManager : Singleton<GameManager>
    {
        public static void StartEncounter()
        {
            SceneManager.LoadScene(1);
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
    }
}