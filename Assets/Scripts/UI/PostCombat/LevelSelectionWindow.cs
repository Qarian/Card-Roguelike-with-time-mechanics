using System;
using System.Collections.Generic;
using Encounter;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PostCombat
{
    public class LevelSelectionWindow : PostCombatWindow
    {
        [SerializeField] private List<Button> options;
        
        public override void ShowWindow()
        {
            gameObject.SetActive(true);
            int optionId = 0;
            foreach (EncounterDifficulty difficulty in Enum.GetValues(typeof(EncounterDifficulty)))
            {
                options[optionId].onClick.AddListener(() => SetDifficulty(difficulty));
                optionId++;
            }
        }

        private void SetDifficulty(EncounterDifficulty newDifficulty)
        {
            PlayerGlobalData.selectedDifficulty = newDifficulty;
            Finalize();
        }
    }
}