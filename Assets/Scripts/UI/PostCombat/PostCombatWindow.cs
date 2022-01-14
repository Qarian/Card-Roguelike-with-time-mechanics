using System;
using UnityEngine;

namespace UI.PostCombat
{
    public abstract class PostCombatWindow : MonoBehaviour
    {
        public Action OnWindowFinalized;
        
        public abstract void ShowWindow();
        
        public abstract void CloseWindow();
    }
}