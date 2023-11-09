using System.Linq;
using Item;
using UnityEngine;

namespace Role {
    [CreateAssetMenu(fileName = "RoleIdentity_肉搏战士", menuName = "纯数据资源/RoleIdentity/肉搏战士")]
    public class RoleIdentity_肉搏战士 : BaseRoleIdentity {
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