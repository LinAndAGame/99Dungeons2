using System.Linq;
using Item;
using UnityEngine;

namespace Role {
    [CreateAssetMenu(fileName = "RoleIdentity_肉搏战士", menuName = "纯数据资源/Role/RoleIdentity/肉搏战士")]
    public class AssetData_RoleIdentity_肉搏战士 : AssetData_BaseRoleIdentity {
        public override bool IsMeetIdentityRequirement(SaveData_Role saveDataRole) {
            foreach (SaveData_Item equippedItemData in saveDataRole.AllItemDatas) {
                if (equippedItemData.AssetData.AllLabels.All(data=>data != ItemLabelEnum.Weapon)) {
                    return false;
                }
            }

            return true;
        }
    }
}