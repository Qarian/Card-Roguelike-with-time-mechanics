using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        [SceneObjectsOnly] [SerializeField] private Button newGameButton;
        [SceneObjectsOnly] [SerializeField] private Button quitButton;

        private void Awake()
        {
            newGameButton.onClick.AddListener(GameManager.StartEncounter);
            quitButton.onClick.AddListener(Application.Quit);
        }
    }
}
