using NewRole;

namespace Card {
    public class RuntimeData_CardEffect_AttackByValueType : BaseRuntimeDataT_CardEffect<SaveData_CardEffect_AttackByValueType> {
        public RuntimeData_CardEffect_AttackByValueType(RuntimeData_Role roleCtrlOwner, SaveData_CardEffect_AttackByValueType saveDataT) : base(roleCtrlOwner, saveDataT) { }

        public override void RunEffect(RuntimeData_Role fromRole, int value, params object[] otherDatas) {
            (otherDatas[0] as RoleCtrl).RuntimeDataRole.Hp.Current -= value;
        }
    }
}