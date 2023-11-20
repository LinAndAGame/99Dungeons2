using System;
using BattleScene;
using UnityEngine;

namespace NewRole {
    public class RoleCtrl : MonoBehaviour {
        public RoleCom_UI     RoleComUI;
        public RoleCom_Effect RoleComEffect;
        
        public RuntimeData_Role RuntimeDataRole { get; private set; }

        public void Init(RuntimeData_Role runtimeDataRole) {
            RuntimeDataRole = runtimeDataRole;
            
            RoleComUI.Init(this);
            RoleComEffect.Init(this);
        }

        public void DestroySelf() {
            RoleComUI.DestroySelf();
        }

        private void OnMouseEnter() {
            BattleSceneCtrl.I.RoleCardCtrlRef.CurMouseTouchingRoleCtrl = this;
            RoleComEffect.SetAsTouchingStyle();
        }

        private void OnMouseExit() {
            BattleSceneCtrl.I.RoleCardCtrlRef.CurMouseTouchingRoleCtrl = null;
            RoleComEffect.SetAsNormalStyle();
        }
    }
}