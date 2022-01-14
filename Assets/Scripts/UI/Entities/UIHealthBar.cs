using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Entities
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private bool healthFromLeft;
        
        [SerializeField] private Scrollbar scrollbar;
        [SerializeField] private TMP_Text healthText;

        private int maxHealth;
        private int currentHealth;

        public void Init(int maxHealth, int currentHealth = -1)
        {
            scrollbar.value = healthFromLeft ? 1 : 0;
            this.maxHealth = maxHealth;
            this.currentHealth = currentHealth >= 0 ? currentHealth : maxHealth;
            UpdateUI();
        }

        public void ChangeHealth(int currentHealth)
        {
            this.currentHealth = currentHealth;
            UpdateUI();
        }

        private void UpdateUI()
        {
            scrollbar.size = currentHealth / (float) maxHealth;
            healthText.text = $"{currentHealth} / {maxHealth}";
        }

    }
}