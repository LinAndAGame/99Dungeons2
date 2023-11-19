using System;
using UnityEngine;

namespace NewSkillCard {
    public class CardCom_EventReceiver : BaseComponent<CardCtrl> {
        public CustomAction OnEnterTouch = new CustomAction();
        public CustomAction OnExitTouch  = new CustomAction();
        public CustomAction OnClick      = new CustomAction();
        public CustomAction OnDrag      = new CustomAction();

        private void OnMouseUpAsButton() {
            OnClick.Invoke();
        }

        private void OnMouseEnter() {
            OnEnterTouch.Invoke();
        }

        private void OnMouseExit() {
            OnExitTouch.Invoke();
        }

        private void OnMouseDrag() {
            OnDrag.Invoke();
        }
    }
}