using UnityEngine;

namespace NewRole {
    public class RoleCtrl : MonoBehaviour {
        public RoleCom_UI     RoleComUI;
        
        public RuntimeData_Role RuntimeDataRole { get; private set; }

        public void Init(RuntimeData_Role runtimeDataRole) {
            RuntimeDataRole = runtimeDataRole;
            
            RoleComUI.Init(this);
        }

        public void DestroySelf() {
            RoleComUI.DestroySelf();
        }
    }
}