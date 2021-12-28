using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Cards
{
    [RequireComponent(typeof(CardUI))]
    public class CardUIMouseInput : UIMouseInput
    {
        [FormerlySerializedAs("raycastReceiver")]
        [SerializeField] private Image cardRaycastReceiver = default;
        private CardUI cardUI;
        private new RectTransform transform;

        private void Awake()
        {
            cardUI = GetComponent<CardUI>();
            transform = GetComponent<RectTransform>();
        }

        protected override void StartHovering()
        {
            UICardPreview.ShowPreview(cardUI.data);
        }

        protected override void EndHovering()
        {
            UICardPreview.HidePreview(cardUI.data);
        }

        protected override void StartDragging()
        {
            cardRaycastReceiver.raycastTarget = false;
            cardUI.Parent.DragAwayCard(cardUI);
        }
        
        protected override void Dragging(Vector2 delta)
        {
            transform.anchoredPosition += delta / CanvasDataProvider.Instance.canvas.scaleFactor;
        }

        protected override void EndDrag(List<GameObject> hovered)
        {
            cardRaycastReceiver.raycastTarget = true;
            
            if (hovered is null)
                return;
            
            foreach (GameObject hoveredObject in hovered)
            {
                ICardReceiver cardReceiver = hoveredObject.GetComponentInParent<ICardReceiver>();
                if (cardReceiver is not null && cardReceiver.CanReceiveCard(cardUI))
                {
                    cardUI.Parent.RemoveCard(cardUI);
                    cardReceiver.ReceiveCard(cardUI);
                    return;
                }
            }
            
            //fallback
            cardUI.Parent.ReturnCard(cardUI);
        }
    }
}