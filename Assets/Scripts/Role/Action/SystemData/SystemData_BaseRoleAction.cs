using MyGameUtility;

namespace Role.Action {
    public abstract class SystemData_BaseRoleAction {
        public string   ActionName;
        public RoleCtrl Owner;
        
        protected CacheCollection CC = new CacheCollection();

        protected SystemData_BaseRoleAction(RoleCtrl owner) {
            Owner = owner;
        }

        public void RunActionSkill() {
            CC.Value.Add(Owner.RoleSystemStatus.IsRunActionSkillEnd.GetCacheElement());
            InternalRunActionSkill();
        }
        
        protected abstract void InternalRunActionSkill();
    }
}