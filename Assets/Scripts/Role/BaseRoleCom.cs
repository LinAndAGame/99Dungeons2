using MyGameUtility;
using UnityEngine;

namespace Role {
    public abstract class BaseRoleCom : MonoBehaviour, IRoleCallback {
        public RoleCtrl RoleOwner;

        protected CacheCollection CC = new CacheCollection();
        
        public virtual void Init() { }

        public virtual void Update() { }

        public virtual void Destroy() { }
    }
}