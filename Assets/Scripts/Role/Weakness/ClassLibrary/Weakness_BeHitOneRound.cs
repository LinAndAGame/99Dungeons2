using Buff;

namespace Role {
    public class Weakness_BeHitOneRound : SystemData_BaseWeakness {
        public Weakness_BeHitOneRound(RoleCtrl owner, SaveData_Weakness saveData) : base(owner, saveData) { }
        protected override void InitToTriggerWeakness() {
            Owner.RoleSystemEvents.OnBeHurtSucceed.AddListener(data => {
                WeaknessValue.Current++;
            }, CC.Event);
        }

        protected override void BreakWeaknessEffect() {
            Owner.RoleSystemValues.BuffSystem.AddBuff(new Buff_Vertigo(Owner, 1));
        }
    }
}