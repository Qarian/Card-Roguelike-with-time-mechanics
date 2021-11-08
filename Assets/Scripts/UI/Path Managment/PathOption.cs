using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PathManagement
{
    public class PathOption : MonoBehaviour
    {
        [SerializeField] private Image background;
        [SerializeField] private TMP_Text tmpText;

        public void SetButton(string text)
        {
            tmpText.text = text;
        }
    }
}
