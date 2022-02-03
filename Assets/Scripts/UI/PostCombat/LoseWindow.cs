using System.Collections.Generic;
using Encounter;
using Managers;
using TMPro;
using UnityEngine;

namespace UI.PostCombat
{
    public class LoseWindow : PostCombatWindow
    {
        [SerializeField] private TMP_Text text;
        
        public override void ShowWindow()
        {
            PlaythroughStats stats = PlayerGlobalData.Stats;
            string message = "You have lost to enemy.\n";
            if (stats.WonEncounters > 0)
            {
                message += "You have entered:\n";
                foreach (KeyValuePair<EncounterDifficulty,int> pair in stats.difficultyCounter)
                {
                    if (pair.Value > 0)
                    {
                        message += $"{pair.Value} {pair.Key} encounters\n";
                    }
                }

                message += "You can still do better.";
            }
            else
            {
                message += "Maybe next time you will be able to defeat at least one.";
            }

            text.text = message;
        }

        public void ReturnToMainMenu()
        {
            GameManager.Instance.ReturnToMainMenu();
        }
    }
}