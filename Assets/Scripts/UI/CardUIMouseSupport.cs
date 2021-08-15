using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Cards
{
    [RequireComponent(typeof(CardUI))]
    public class CardUIMouseSupport : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private CardUI cardUI;
        
        private void Awake()
        {
            cardUI = GetComponent<CardUI>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            UICardPreview.ShowPreview(cardUI.data);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UICardPreview.HidePreview(cardUI.data);
        }

        public void OnPointerDown(PointerEventData pointerEventData)
        {
            UICardPreview.HidePreview(cardUI.data);
        }

        //Detect if clicks are no longer registering
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            if (pointerEventData.hovered.Contains(gameObject))
                UICardPreview.ShowPreview(cardUI.data);
        }
    }
}