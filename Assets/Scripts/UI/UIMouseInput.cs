using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public abstract class UIMouseInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private bool hovering = false;
        private bool dragging = false;

        private bool enableHovering = true;
        private bool enableDragging = true;

        protected bool EnableHovering
        {
            get => enableHovering;
            set
            {
                if (hovering && enableHovering != value)
                {
                    if (value)
                        StartHovering();
                    else
                        EndHovering();
                }
                enableHovering = value;
            }
        }

        protected bool EnableDragging
        {
            get => enableDragging = true;
            set => enableDragging = value;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (enableHovering)
                StartHovering();
            hovering = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (enableHovering)
                EndHovering();
            hovering = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!EnableDragging) return;
            
            if (enableHovering)
                EndHovering();
            StartDragging();
            dragging = true;
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            if (dragging)
                Dragging(eventData.delta);
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!dragging) return;
            
            EndDrag(eventData.hovered);
            if (hovering && enableHovering)
                StartHovering();
        }

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            eventData.useDragThreshold = false;
        }

        private void OnDestroy()
        {
            if(hovering && enableHovering)
                EndHovering();
            if (EnableDragging)
                EndDrag(null);
        }

        protected virtual void StartHovering() { }
        protected virtual void EndHovering() { }
        protected virtual void StartDragging() { }
        protected virtual void Dragging(Vector2 delta) { }
        protected virtual void EndDrag(List<GameObject> hovered) { }
    }
}