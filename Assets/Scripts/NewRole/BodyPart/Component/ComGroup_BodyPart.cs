using Card;
using Dungeon.EncounterEnemy;
using MyGameUtility;
using UnityEngine;
using Utility;

namespace NewRole {
    public class ComGroup_BodyPart : MonoBehaviour {
        public MouseEventReceiver MouseEventReceiverRef;
        public Com_BodyPartUI     ComBodyPartUIRef;
        public Transform          EquipmentParentTrans;

        private CacheCollection _CC = new CacheCollection();
        
        public RoleCtrl             RoleCtrlOwner { get; private set; }
        public RuntimeData_BodyPart RuntimeData   { get; private set; }

        public void Init(RoleCtrl roleCtrlOwner, RuntimeData_BodyPart runtimeDataBodyPart) {
            RoleCtrlOwner = roleCtrlOwner;
            RuntimeData   = runtimeDataBodyPart;

            foreach (var componentsInChild in this.GetComponentsInChildren<BaseComponent<ComGroup_BodyPart>>()) {
                componentsInChild.Init(this);
            }

            if (RuntimeData.RuntimeDataEquipment != null) {
                var equipment = Instantiate(GameCommonAsset.I.ComGroupEquipmentPrefab, EquipmentParentTrans);
                equipment.Init(RuntimeData.RuntimeDataEquipment);
            }

            RegisteMouseTouchEffect();
            
            runtimeDataBodyPart.OnDisabilityStateChanged.AddListener(data => {
                if (data == false) {
                    Recovery();
                }
                else {
                    Disability();
                }
            });
        }

        private void Disability() {
            _CC.Clear();
            this.transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        private void Recovery() {
            this.transform.localEulerAngles = Vector3.zero;
            RegisteMouseTouchEffect();
        }

        private void RegisteMouseTouchEffect() {
            
        }
    }
}