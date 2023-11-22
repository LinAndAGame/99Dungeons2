using System.Collections.Generic;
using Dungeon.EncounterEnemy;
using NewRole;

namespace Card {
    public class RuntimeData_CardEffect_Heal : BaseRuntimeDataT_CardEffect<SaveData_CardEffect_Heal> {
        public RuntimeData_CardEffect_Heal(RuntimeData_Role roleCtrlOwner, SaveData_CardEffect_Heal saveDataT) : base(roleCtrlOwner, saveDataT) { }

        public override void RunEffect(RuntimeData_Role fromRole, int value, params object[] otherDatas) {
            fromRole.Hp.Current += value;
        }
    }
}