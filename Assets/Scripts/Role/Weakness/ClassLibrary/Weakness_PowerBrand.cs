using Buff;

namespace Role {
    public class Weakness_PowerBrand : SystemData_BaseWeakness {
        public Weakness_PowerBrand(RoleCtrl owner, SaveData_Weakness saveData) : base(owner, saveData) { }
        protected override void InitToTriggerWeakness() {
            Owner.RoleSystemEvents.OnAttackSucceed.AddListener(data => {
                WeaknessValue.Current += data.TotalDamage;
            }, CC.Event);
        }

        protected override void BreakWeaknessEffect() {
            // Owner.RoleSystemValues.BuffSystem.AddBuff(new Buff_Vertigo(Owner, 1));
        }
    }
}