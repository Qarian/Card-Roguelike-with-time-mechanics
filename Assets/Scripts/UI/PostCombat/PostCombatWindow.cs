using System;
using UnityEngine;

namespace UI.PostCombat
{
    public abstract class PostCombatWindow : MonoBehaviour
    {
        public event Action OnWindowFinalized;
        
        public abstract void ShowWindow();

        public virtual void CloseWindow()
        {
            gameObject.SetActive(false);
        }

        protected void Close()
        {
            OnWindowFinalized?.Invoke();
        }
    }
}