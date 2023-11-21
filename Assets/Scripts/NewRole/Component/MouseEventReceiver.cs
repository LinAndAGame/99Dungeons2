using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NewRole {
    public class MouseEventReceiver : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
        public CustomAction                   OnMouseExitAct       = new CustomAction();
        public CustomAction                   OnMouseEnterAct      = new CustomAction();
        public CustomAction                   OnMouseUpAsButtonAct = new CustomAction();
        public CustomAction                   OnMouseUpAct         = new CustomAction();
        public CustomAction<PointerEventData> OnBeginDragAct       = new CustomAction<PointerEventData>();
        public CustomAction<PointerEventData> OnDragAct            = new CustomAction<PointerEventData>();
        public CustomAction<PointerEventData> OnEndDragAct         = new CustomAction<PointerEventData>();

        private void OnMouseUpAsButton() {
            OnMouseUpAsButtonAct.Invoke();
        }

        private void OnMouseEnter() {
            OnMouseEnterAct.Invoke();
        }

        private void OnMouseExit() {
            OnMouseExitAct.Invoke();
        }

        private void OnMouseUp() {
            OnMouseUpAct.Invoke();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            OnBeginDragAct.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData) {
            OnDragAct.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData) {
            OnEndDragAct.Invoke(eventData);
        }
    }
}