using UnityEngine;

namespace Role.Action {
    [CreateAssetMenu(fileName = "RoleAction_治疗所有友军", menuName = "纯数据资源/Role/RoleAction/治疗所有友军")]
    public class AssetData_HealAllFriendlyRole : AssetData_RoleAction {
        public          float               HealValue = 5;
        
        public override SaveData_RoleAction GetSaveData() {
            return new SaveData_HealAllFriendlyRoles(this);
        }
    }
}