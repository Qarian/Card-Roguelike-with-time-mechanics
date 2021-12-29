using UnityEngine;
using UnityEngine.UI;

namespace UI.Timeline
{
    public class EntityIndicator : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Image background;
        

        private new RectTransform transform;

        public void Init(EntityIndicationData data)
        {
            transform = GetComponent<RectTransform>();
            image.sprite = data.image;
            image.color = data.color;

            background.color = Random.ColorHSV(0, 0.2f, 0.8f, 0.92f, 0.7f, 0.8f);
        }

        public void SetPositionOnTimeline(float x)
        {
            x = Mathf.Clamp01(x);
            transform.anchorMin = new Vector2(x, 0.5f);
            transform.anchorMax = new Vector2(x, 0.5f);
        }
    }
}