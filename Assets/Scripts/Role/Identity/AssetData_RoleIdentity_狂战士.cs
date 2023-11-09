using System.Linq;
using Item;
using UnityEngine;

namespace Role {
    [CreateAssetMenu(fileName = "RoleIdentity_狂战士", menuName = "纯数据资源/Role/RoleIdentity/狂战士")]
    public class AssetData_RoleIdentity_狂战士 : AssetData_BaseRoleIdentity {
        public override bool IsMeetIdentityRequirement(SaveData_Role saveDataRole) {
            foreach (SaveData_Item equippedItemData in saveDataRole.AllItemDatas) {
                if (equippedItemData.AssetData.AllLabels.All(data=>data != "Weapon")) {
                    return false;
                }
            }

            return true;
        }
    }
}