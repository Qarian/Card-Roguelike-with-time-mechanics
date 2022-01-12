using System.Collections.Generic;
using Sirenix.Serialization;
using UI.PostCombat;
using Utilities;

namespace Managers
{
    public class PostCombatManager : Singleton<PostCombatManager>
    {
        [OdinSerialize] public List<IPostCombatWindow> postCombatWindows = new ();

        private void Start()
        {
            gameObject.SetActive(false);
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

        private void GoToNextWindow(int windowIndex)
        {
            postCombatWindows[windowIndex].CloseWindow();
            postCombatWindows[windowIndex + 1].ShowWindow();
        }

        private void FinishedLastWindow()
        {
            
        }
    }
}
