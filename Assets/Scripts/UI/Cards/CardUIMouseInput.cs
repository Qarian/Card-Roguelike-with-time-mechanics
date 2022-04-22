using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Zenject;

namespace UI.Cards
{
    [RequireComponent(typeof(CardUI))]
    public class CardUIMouseInput : UIMouseInput
    {
        [SerializeField] private Image cardRaycastReceiver = default;
        private CardUI cardUI;
        private new RectTransform transform;

        private Canvas canvas;

        [Inject]
        private void Init(CanvasProvider canvasProvider)
        {
            canvas = canvasProvider.canvas;
        }

        private void Awake()
        {
            cardUI = GetComponent<CardUI>();
            transform = GetComponent<RectTransform>();
        }

        protected override void StartDragging()
        {
            cardRaycastReceiver.raycastTarget = false;
            cardUI.Parent.DragAwayCard(cardUI);
        }
        
        protected override void Dragging(Vector2 delta)
        {
            transform.anchoredPosition += delta / canvas.scaleFactor;
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
        
        public class Factory : PlaceholderFactory<CardUIMouseInput> { }
    }
}