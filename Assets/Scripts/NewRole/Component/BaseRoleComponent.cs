using MyGameUtility;
using UnityEngine;

namespace NewRole {
    public abstract class BaseRoleComponent : MonoBehaviour {
        protected CacheCollection CC = new CacheCollection();
        
        protected RoleCtrl RoleCtrlRef { get; private set; }

        public virtual void Init(RoleCtrl roleCtrl) {
            RoleCtrlRef = roleCtrl;
        }

        public void DestroySelf() {
            CC.Clear();
        }
    }
}