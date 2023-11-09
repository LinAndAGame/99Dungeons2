using Damage;
using UnityEngine;

namespace Role.UnlockAction {
    [CreateAssetMenu(fileName = "被火焰攻击击中", menuName = "纯数据资源/Role/UnlockAction/被火焰攻击击中", order = 0)]
    public class FixedData_BeHitValue : BaseRoleUnlockFixedData {
        public float                 TriggerValue;
        public DamageElementTypeEnum DamageElementType;
        
        public override SaveData_RoleUnlock GetRoleUnlockData() {
            return new SaveData_BeHitValue(this);
        }
    }
}