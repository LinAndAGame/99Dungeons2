using System.Collections.Generic;
using System.Linq;
using Dungeon.EncounterEnemy;
using NewRole;

namespace Card {
    public class RuntimeData_CardEffect_AttackByValueType : BaseRuntimeDataT_CardEffect<SaveData_CardEffect_AttackByValueType> {
        public RuntimeData_CardEffect_AttackByValueType(SaveData_CardEffect_AttackByValueType saveDataT) : base(saveDataT) { }

        public override bool CanAddOtherData(RoleCtrl fromRole, object otherData) {
            if (otherData is RoleCtrl otherRoleCtrl) {
                return DungeonEvent_EncounterEnemyCtrl.I.GetAllOtherRoles(fromRole).Contains(otherRoleCtrl);
            }

            return base.CanAddOtherData(fromRole, otherData);
        }

        public override bool CanRunEffect(RoleCtrl fromRole, params object[] otherDatas) {
            return otherDatas.Length == 1 && otherDatas[0] is RoleCtrl;
        }

        public override void RunEffect(RoleCtrl fromRole, int value, params object[] otherDatas) {
            (otherDatas[0] as RoleCtrl).RuntimeDataRole.Hp.Current -= value;
        }
    }
}