using NewRole;

namespace Card {
    public class RuntimeData_CardEffect_Heal : BaseRuntimeDataT_CardEffect<SaveData_CardEffect_Heal> {
        public RuntimeData_CardEffect_Heal(SaveData_CardEffect_Heal saveDataT) : base(saveDataT) { }
        
        public override void RunEffect(RoleCtrl fromRole, RoleCtrl toRole, int value) {
            fromRole.RuntimeDataRole.Hp.Current += value;
        }
    }
}