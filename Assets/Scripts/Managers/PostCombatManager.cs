using System.Collections.Generic;
using UI.PostCombat;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class PostCombatManager : Singleton<PostCombatManager>
    {
        [SerializeField] private List<PostCombatWindow> postCombatWindows = new ();

        private void Start()
        {
            gameObject.SetActive(false);
            instance = this;
        }

        public void StartEndSequence()
        {
            for (int i = 0; i < postCombatWindows.Count - 1; i++)
            {
                var i1 = i;
                postCombatWindows[i].OnWindowFinalized += () => GoToNextWindow(i1);
                
                postCombatWindows[i].gameObject.SetActive(false);
            }
            postCombatWindows[^1].OnWindowFinalized += FinishedLastWindow;
            postCombatWindows[^1].gameObject.SetActive(false);
            
            gameObject.SetActive(true);
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
