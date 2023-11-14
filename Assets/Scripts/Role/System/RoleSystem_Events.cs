using Damage;
using Role.Action;

namespace Role {
    public class RoleSystem_Events : BaseRoleSystem {
        public CustomAction<DamageData> OnBeHurtFailure = new CustomAction<DamageData>();
        public CustomAction<DamageData> OnBeHurtSucceed = new CustomAction<DamageData>();
        public CustomAction<DamageData> OnAttackFailure = new CustomAction<DamageData>();
        public CustomAction<DamageData> OnAttackSucceed = new CustomAction<DamageData>();

        public CustomAction<SystemData_BaseWeakness> OnWeaknessBroken = new CustomAction<SystemData_BaseWeakness>();

        public CustomAction OnActionSkillEnd = new CustomAction();

        public CustomAction<SystemData_BaseRoleAction> OnCurActionSkillChanged = new CustomAction<SystemData_BaseRoleAction>();

        public CustomAction OnFightWinBefore = new CustomAction();
        public CustomAction OnFightFailure   = new CustomAction();

        public CustomAction OnAnimationAttack = new CustomAction();
        
        public RoleSystem_Events(RoleCtrl roleOwner) : base(roleOwner) { }

        public override void Init() {
            base.Init();
            OnWeaknessBroken.AddListener(data => {
                RoleOwner.RoleSystemValues.RemoveWeakness(data);
            }, CC.Event);
        }
    }
}