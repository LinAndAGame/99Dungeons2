using System;
using BattleScene;
using Dungeon.EncounterEnemy;
using UnityEngine;

namespace NewRole {
    public class RoleCtrl : MonoBehaviour {
        public MouseEventReceiver    MouseEventReceiverRef;
        public RoleCom_UI            RoleComUI;
        public RoleCom_Effect        RoleComEffect;

        public RuntimeData_Role RuntimeDataRole { get; private set; }

        public void Init(RuntimeData_Role runtimeDataRole) {
            RuntimeDataRole               = runtimeDataRole;
            RuntimeDataRole.RoleCtrlOwner = this;
            
            foreach (var baseComponent in this.GetComponents<BaseComponent<RoleCtrl>>()) {
                baseComponent.Init(this);
            }
            
            MouseEventReceiverRef.OnMouseEnterAct.AddListener(() => {
                DungeonEvent_EncounterEnemyCtrl.I.CurTouchingRoleCtrl = this;
                RoleComEffect.SetAsTouchingStyle();
            });
            MouseEventReceiverRef.OnMouseExitAct.AddListener(() => {
                DungeonEvent_EncounterEnemyCtrl.I.CurTouchingRoleCtrl = null;
                RoleComEffect.SetAsNormalStyle();
            });
        }

        public void DestroySelf() {
            foreach (var baseComponent in this.GetComponents<BaseComponent<RoleCtrl>>()) {
                baseComponent.DestroySelf();
            }
            Destroy(this.gameObject);
        }

        public void Death() {
            Debug.Log("角色死亡");
            DestroySelf();
        }
    }
}