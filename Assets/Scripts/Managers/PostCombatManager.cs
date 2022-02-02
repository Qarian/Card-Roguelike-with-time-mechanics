using System.Collections.Generic;
using UI.PostCombat;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class PostCombatManager : Singleton<PostCombatManager>
    {
        [SerializeField] private PostCombatWindow loseWindow;
        [SerializeField] private List<PostCombatWindow> postCombatWindows = new ();

        private void Awake()
        {
            foreach (PostCombatWindow window in postCombatWindows)
            {
                window.gameObject.SetActive(false);
            }
            //loseWindow.gameObject.SetActive(false);
            
            gameObject.SetActive(false);
            instance = this;
        }

        public void StartEndSequence()
        {
            for (int i = 0; i < postCombatWindows.Count - 1; i++)
            {
                var i1 = i;
                postCombatWindows[i].OnWindowFinalized += () => GoToNextWindow(i1);
            }
            postCombatWindows[^1].OnWindowFinalized += FinishedLastWindow;
            
            gameObject.SetActive(true);
            postCombatWindows[0].ShowWindow();
        }

        public void ShowLoseScreen()
        {
            loseWindow.gameObject.SetActive(true);
            postCombatWindows[0].ShowWindow();
        }

        private void GoToNextWindow(int windowIndex)
        {
            postCombatWindows[windowIndex].CloseWindow();
            postCombatWindows[windowIndex + 1].ShowWindow();
        }

        private void FinishedLastWindow()
        {
            GameManager.NewEncounter();
        }
    }
}
