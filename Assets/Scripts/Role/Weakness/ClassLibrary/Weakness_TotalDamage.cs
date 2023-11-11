using Buff;

namespace Role {
    public class Weakness_TotalDamage : SystemData_BaseWeakness {
        protected override void InitToTriggerWeakness() {
            Owner.RoleSystemEvents.OnBeHurtSucceed.AddListener(data => {
                WeaknessValue.Current -= data.TotalDamage;
            }, CC.Event);
        }

        protected override void BreakWeaknessEffect() {
            Owner.RoleSystemValues.BuffSystem.AddBuff(new Buff_Vertigo(Owner, 1));
        }

        public Weakness_TotalDamage(RoleCtrl owner, SaveData_Weakness saveData) : base(owner, saveData) { }
    }
}