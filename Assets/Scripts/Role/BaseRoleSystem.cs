using MyGameUtility;

namespace Role {
    public abstract class BaseRoleSystem : IRoleCallback {
        protected CacheCollection CC = new CacheCollection();
        
        protected readonly RoleCtrl RoleOwner;

        public BaseRoleSystem(RoleCtrl roleOwner) {
            RoleOwner = roleOwner;
        }
        
        public virtual void Init() { }

        public virtual void Update() { }

        public virtual void Destroy() {
            CC.Clear();
        }
    }
}