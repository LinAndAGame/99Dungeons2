using MyGameUtility;

namespace Role.UnlockAction {
    public class SaveData_BeHitValue : BaseRoleUnlockWithFixedData<FixedData_BeHitValue> {
        public MinMaxValueFloat      TriggerValue;

        public SaveData_BeHitValue(BaseRoleUnlockFixedData roleUnlockFixedData) : base(roleUnlockFixedData) {
            TriggerValue = new MinMaxValueFloat(0, FixedData.TriggerValue, 0);
        }

        public override void Init(SaveData_Role saveDataRole) {
            TriggerValue.OnCurValueEqualsMax.AddListener(() => {
                saveDataRole.AllRoleActionDatas.AddRange(FixedData.GetAllSaveDataRoleActions);
            }, CC.Event);
        }

        public override BaseRoleUnlockActionBattle GetRoleUnlockActionBattle() {
            return new SystemData_BeHitValue(this);
        }
    }
}