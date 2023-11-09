namespace Role.UnlockAction {
    public class SystemData_BeHitValue : BaseRoleUnlockActionBattleWithPlayerData<SaveData_BeHitValue> {
        private float _TotalValue;
        
        public SystemData_BeHitValue(SaveData_BeHitValue saveData) : base(saveData) { }
        
        public override void InitOnBattle(RoleCtrl roleCtrl) {
            roleCtrl.RoleSystemEvents.OnBeHurtSucceed.AddListener(data => {
                if (data.DamageElementType == SaveData.FixedData.DamageElementType) {
                    _TotalValue += data.TotalDamage;
                }
            });
        }

        public override bool CheckIsMeetUnlockRequirement() {
            SaveData.TriggerValue.Current += _TotalValue;
            if (SaveData.TriggerValue.IsEqualMax) {
                return true;
            }

            return false;
        }
    }
}