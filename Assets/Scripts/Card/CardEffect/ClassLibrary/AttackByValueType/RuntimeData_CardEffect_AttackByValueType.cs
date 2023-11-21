using System.Collections.Generic;
using BattleScene;
using RoleCtrl = NewRole.RoleCtrl;

namespace Card {
    public class RuntimeData_CardEffect_AttackByValueType : BaseRuntimeDataT_CardEffect<SaveData_CardEffect_AttackByValueType> {
        public RuntimeData_CardEffect_AttackByValueType(SaveData_CardEffect_AttackByValueType saveDataT) : base(saveDataT) { }
        
        public override void RunEffect(RoleCtrl fromRole, RoleCtrl toRole, int value) {
            toRole.RuntimeDataRole.Hp.Current -= value;
        }

        public override List<RoleCtrl> GetSelectTargetsOnDrag() {
            return BattleSceneCtrl.I.AllRoleCtrls;
        }
    }
}