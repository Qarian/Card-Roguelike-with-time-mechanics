using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Cards
{
    [RequireComponent(typeof(CardUI))]
    public class CardUIMouseSupport : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Image raycastReceiver = default;
        private CardUI cardUI;
        private new RectTransform transform;

        private void Awake()
        {
            cardUI = GetComponent<CardUI>();
            transform = GetComponent<RectTransform>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            UICardPreview.ShowPreview(cardUI.data);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UICardPreview.HidePreview(cardUI.data);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.anchoredPosition += eventData.delta / CanvasDataProvider.Instance.canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            cardUI.Parent.DragCard(cardUI);
            raycastReceiver.raycastTarget = false;
            UICardPreview.HidePreview(cardUI.data);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            raycastReceiver.raycastTarget = true;
            foreach (GameObject hoveredObject in eventData.hovered)
            {
                if (hoveredObject.TryGetComponent(out ICardHolder cardHolder))
                {
                    if (cardHolder.CanReceiveCard(cardUI))
                    {
                        cardUI.Parent.RemoveCard(cardUI);
                        cardHolder.ReceiveCard(cardUI);
                        return;
                    }
                }
            }
            
            //fallback
            cardUI.Parent.ReturnCard(cardUI);
        }

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            eventData.useDragThreshold = false;
        }
    }
}