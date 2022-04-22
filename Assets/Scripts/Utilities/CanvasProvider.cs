using UnityEngine;

namespace Utilities
{
    [RequireComponent(typeof(Canvas))]
    public class CanvasProvider : MonoBehaviour
    {
        public Canvas canvas { get; private set; }

        protected void Awake()
        {
            canvas = GetComponent<Canvas>();
        }
    }
}