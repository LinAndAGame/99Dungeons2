using System.Collections.Generic;
using Item;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Role.RoleBody {
    [CreateAssetMenu(fileName = "装备槽", menuName = "纯数据资源/Role/EquipmentSlot")]
    public class AssetData_RoleItemSlot : ScriptableObject {
        public AssetData_Item DefaultEquippedItem;
        [ValueDropdown(nameof(AllLabelNames), IsUniqueList = true)]
        public List<string> AllAllowedItemLabels;

        private List<string> AllLabelNames => ItemLabelAsset.I.AllAllowedItemLabelNames;

        public SaveData_RoleItemSlot GetSaveData() {
            return new SaveData_RoleItemSlot(this);
        }
    }
}