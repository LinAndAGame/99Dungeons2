using NewRole;
using UnityEngine;

namespace Equipment {
    public class ComGroup_Equipment : MonoBehaviour {
        public MouseEventReceiver MouseEventReceiverRef;
        public Com_EquipmentUI    ComEquipmentUIRef;

        public RuntimeData_Equipment RuntimeData { get; private set; }
        
        public void Init(RuntimeData_Equipment runtimeDataEquipment) {
            RuntimeData = runtimeDataEquipment;

            foreach (var componentsInChild in this.GetComponentsInChildren<BaseComponent<ComGroup_Equipment>>()) {
                componentsInChild.Init(this);
            }
        }

        public void DestroySelf() {
            
        }
    }
}