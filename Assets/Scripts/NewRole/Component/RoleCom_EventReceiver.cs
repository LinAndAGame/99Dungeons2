using System;
using UnityEngine;

namespace NewRole {
    public class RoleCom_EventReceiver : BaseComponent<RoleCtrl> {
        public CustomAction OnEnterTouch = new CustomAction();
        public CustomAction OnExitTouch  = new CustomAction();
        public CustomAction OnClick      = new CustomAction();

        private void OnMouseUpAsButton() {
            OnClick.Invoke();
        }

        private void OnMouseEnter() {
            OnEnterTouch.Invoke();
        }

        private void OnMouseExit() {
            OnExitTouch.Invoke();
        }
    }
}