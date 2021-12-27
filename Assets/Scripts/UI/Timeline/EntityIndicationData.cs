using UnityEngine;

namespace UI.Timeline
{
    public class EntityIndicationData
    {
        public Sprite image;
        public Color color;

        public EntityIndicationData(Sprite image, Color color)
        {
            this.color = color;
            this.image = image;
        }
    }
}
