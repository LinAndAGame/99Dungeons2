using MyGameUtility;

namespace Role {
    public class RoleSystem_Status : BaseRoleSystem {
        public ValueCacheBool CanAttack           = true;
        public ValueCacheBool CanBeHurt           = true;
        public ValueCacheBool IsRunActionSkillEnd = true;

        public RoleSystem_Status(RoleCtrl roleOwner) : base(roleOwner) { }
    }
}