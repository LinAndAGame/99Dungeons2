using Card;
using Dungeon.EncounterEnemy;
using MyGameUtility;
using UnityEngine;

namespace NewRole {
    public class BodyPartCtrl : MonoBehaviour {
        public MouseEventReceiver MouseEventReceiverRef;

        private CacheCollection _CC = new CacheCollection();
        
        public RoleCtrl             RoleCtrlOwner { get; private set; }
        public RuntimeData_BodyPart RuntimeData   { get; private set; }

        public void Init(RoleCtrl roleCtrlOwner, RuntimeData_BodyPart runtimeDataBodyPart) {
            RoleCtrlOwner = roleCtrlOwner;
            RuntimeData   = runtimeDataBodyPart;

            RegisteMouseTouchEffect();
        }

        public void EquipCard(CardCtrl cardCtrl) {
            
        }

        public void Disability() {
            RuntimeData.Disability();
            _CC.Clear();
        }

        public void Recovery() {
            RuntimeData.Recovery();
            RegisteMouseTouchEffect();
        }

        private void RegisteMouseTouchEffect() {
            MouseEventReceiverRef.OnMouseEnterAct.AddListener(() => {
                DungeonEvent_EncounterEnemyCtrl.I.CurTouchingBodyPartCtrl = this;
            }, _CC.Event);
            MouseEventReceiverRef.OnMouseExitAct.AddListener(() => {
                DungeonEvent_EncounterEnemyCtrl.I.CurTouchingBodyPartCtrl = null;
            }, _CC.Event);
        }
    }
}