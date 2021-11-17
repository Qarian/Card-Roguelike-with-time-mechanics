using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Cards
{
    [RequireComponent(typeof(CardUI))]
    public class CardUIMouseSupport : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler
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
            cardUI.Parent.DragAwayCard(cardUI);
            cardRaycastReceiver.raycastTarget = false;
            UICardPreview.HidePreview(cardUI.data);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            cardRaycastReceiver.raycastTarget = true;
            foreach (GameObject hoveredObject in eventData.hovered)
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

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            eventData.useDragThreshold = false;
        }
    }
}