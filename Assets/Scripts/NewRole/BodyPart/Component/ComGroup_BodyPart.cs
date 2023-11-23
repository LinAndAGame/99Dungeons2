using Card;
using Dungeon.EncounterEnemy;
using MyGameUtility;
using UnityEngine;

namespace NewRole {
    public class ComGroup_BodyPart : MonoBehaviour {
        public MouseEventReceiver MouseEventReceiverRef;
        public Com_BodyPartUI     ComBodyPartUIRef;

        private CacheCollection _CC = new CacheCollection();
        
        public RoleCtrl             RoleCtrlOwner { get; private set; }
        public RuntimeData_BodyPart RuntimeData   { get; private set; }

        public void Init(RoleCtrl roleCtrlOwner, RuntimeData_BodyPart runtimeDataBodyPart) {
            RoleCtrlOwner = roleCtrlOwner;
            RuntimeData   = runtimeDataBodyPart;

            foreach (var componentsInChild in this.GetComponentsInChildren<BaseComponent<ComGroup_BodyPart>>()) {
                componentsInChild.Init(this);
            }

            RegisteMouseTouchEffect();
        }

        public void EquipCard(CardCtrl cardCtrl) {
            
        }

        public void Disability() {
            _CC.Clear();
            RuntimeData.Disability();
            ComBodyPartUIRef.SetAsDisabilityStyle();
        }

        public void Recovery() {
            RuntimeData.Recovery();
            ComBodyPartUIRef.SetAsNormalStyle();
            RegisteMouseTouchEffect();
        }

        private void RegisteMouseTouchEffect() {
            
        }
    }
}