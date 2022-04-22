using Character;
using Difficulty;
using Encounter;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using Zenject;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Inject]
        private PostCombatManager postCombatManager;
        
        public static void StartEncounter(PlayerDataScriptable playerDataScriptable)
        {
            PlayerGlobalData.StartNewGame(playerDataScriptable);
            PlayerGlobalData.selectedDifficulty = EncounterDifficulty.Normal;
            DifficultyScaler.StartGameplay();
            NewEncounter();
        }

        public static void NewEncounter()
        {
            SceneManager.LoadScene(1);
        }

        public void EndEncounter(bool win)
        {
            DifficultyScaler.EndEncounter();
            
            PlayerGlobalData.Current.currentHealth = Mathf.Clamp(
                (int)(PlayerGlobalData.Current.currentHealth + PlayerGlobalData.Current.maxHealth * 0.2f),
                0, PlayerGlobalData.Current.maxHealth);
            
            if (win)
            {
                postCombatManager.StartEndSequence();
            }
            else
            {
                postCombatManager.ShowLoseScreen();
            }
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}