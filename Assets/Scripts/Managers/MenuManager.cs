using Character;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public PlayerDataScriptable playerData;
        
        [SceneObjectsOnly] [SerializeField] private Button newGameButton;
        [SceneObjectsOnly] [SerializeField] private Button quitButton;

        private void Awake()
        {
            newGameButton.onClick.AddListener(() => GameManager.StartEncounter(playerData));
            quitButton.onClick.AddListener(Application.Quit);
        }
    }
}
