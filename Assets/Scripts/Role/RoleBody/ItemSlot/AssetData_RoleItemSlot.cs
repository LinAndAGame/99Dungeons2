using System.Collections.Generic;
using Item;
using MyGameUtility;
using UnityEngine;

namespace Role.RoleBody {
    [CreateAssetMenu(fileName = "RoleItemSlot", menuName = "纯数据资源/Role/ItemSlot")]
    public class AssetData_RoleItemSlot : BaseAssetData {
        public AssetData_Item      OriginalCanNotRemovedItem;
        public List<ItemLabelEnum> AllAllowedItemLabels;

        public SaveData_RoleItemSlot GetSaveData() {
            return new SaveData_RoleItemSlot(this);
        }
    }
}