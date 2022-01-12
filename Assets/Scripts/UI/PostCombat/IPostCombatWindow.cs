using System;

namespace UI.PostCombat
{
    public interface IPostCombatWindow
    {
        public event Action OnWindowFinalized;
        public void ShowWindow();
        
        public void CloseWindow();
    }
}