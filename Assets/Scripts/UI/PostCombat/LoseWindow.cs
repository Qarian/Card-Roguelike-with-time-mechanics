using Managers;

namespace UI.PostCombat
{
    public class LoseWindow : PostCombatWindow
    {
        public override void ShowWindow()
        {
            
        }

        public void ReturnToMainMenu()
        {
            GameManager.Instance.ReturnToMainMenu();
        }
    }
}