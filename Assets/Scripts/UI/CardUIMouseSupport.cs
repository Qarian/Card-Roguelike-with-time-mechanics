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
            raycastReceiver.raycastTarget = false;
            UICardPreview.HidePreview(cardUI.data);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            raycastReceiver.raycastTarget = true;
            foreach (GameObject hoveredObject in eventData.hovered)
            {
                ICardHolder cardHolder;
                if (hoveredObject.TryGetComponent(out cardHolder))
                {
                    if (cardHolder.ReceiveCard(cardUI))
                    {
                        // End function if card was taken
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