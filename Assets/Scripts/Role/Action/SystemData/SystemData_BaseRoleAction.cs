using MyGameUtility;

namespace Role.Action {
    public abstract class SystemData_BaseRoleAction {
        public RoleCtrl Owner;
        
        public    SaveData_RoleAction SaveData { get; private set; }
        protected CacheCollection     CC = new CacheCollection();

        protected SystemData_BaseRoleAction(SaveData_RoleAction saveDataRoleAction, RoleCtrl owner) {
            SaveData = saveDataRoleAction;
            Owner    = owner;
        }

        public void RunActionSkill() {
            CC.Value.Add(Owner.RoleSystemStatus.IsRunActionSkillEnd.GetCacheElement());
            InternalRunActionSkill();
        }
        
        protected abstract void InternalRunActionSkill();
    }
}