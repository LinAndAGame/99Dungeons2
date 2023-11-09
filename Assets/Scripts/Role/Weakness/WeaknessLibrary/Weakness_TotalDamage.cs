namespace Role {
    public class Weakness_TotalDamage : BaseWeakness {
        protected override void InitToTriggerWeakness() {
            Owner.RoleSystemEvents.OnBeHurtSucceed.AddListener(data => {
                WeaknessValue.Current -= data.TotalDamage;
            });
        }

        protected override void BreakWeaknessEffect() {
            Owner.RoleSystemValues.BuffSystem.AddBuff(new RoleBuff_Vertigo(Owner, 1));
        }
    }
}