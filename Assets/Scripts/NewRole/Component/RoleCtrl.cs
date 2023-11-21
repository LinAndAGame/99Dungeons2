using System;
using BattleScene;
using UnityEngine;

namespace NewRole {
    public class RoleCtrl : MonoBehaviour {
        public MouseEventReceiver    MouseEventReceiverRef;
        public RoleCom_UI            RoleComUI;
        public RoleCom_Effect        RoleComEffect;

        public RuntimeData_Role RuntimeDataRole { get; private set; }

        public void Init(RuntimeData_Role runtimeDataRole) {
            RuntimeDataRole = runtimeDataRole;
            
            foreach (var baseComponent in this.GetComponents<BaseComponent<RoleCtrl>>()) {
                baseComponent.Init(this);
            }
            
            RuntimeDataRole.DrawCards();
            
            MouseEventReceiverRef.OnMouseEnterAct.AddListener(() => {
                BattleSceneCtrl.I.CardLayoutCtrlRef.CurMouseTouchingRoleCtrl = this;
                RoleComEffect.SetAsTouchingStyle();
            });
            MouseEventReceiverRef.OnMouseExitAct.AddListener(() => {
                BattleSceneCtrl.I.CardLayoutCtrlRef.CurMouseTouchingRoleCtrl = null;
                RoleComEffect.SetAsNormalStyle();
            });
        }

        public void DestroySelf() {
            RoleComUI.DestroySelf();
            Destroy(this.gameObject);
        }
    }
}