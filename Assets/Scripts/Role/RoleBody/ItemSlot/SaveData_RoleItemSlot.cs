using System;
using System.Linq;
using Item;
using UnityEngine;
using Utility;

namespace Role.RoleBody {
    [Serializable]
    public class SaveData_RoleItemSlot {
        [SerializeField]
        private SaveData_Item OriginalCanNotRemovedItem;
        
        [SerializeField]
        private string AssetDataPath;

        public SaveData_Item OverrideItem;

        public SaveData_Item EquippedItem {
            get {
                if (OverrideItem != null) {
                    return OverrideItem;
                }

                return OriginalCanNotRemovedItem;
            }
        }
        
        public AssetData_RoleItemSlot AssetData => Resources.Load<AssetData_RoleItemSlot>(AssetDataPath);

        public SaveData_RoleItemSlot() { }
        
        public SaveData_RoleItemSlot(AssetData_RoleItemSlot assetData) {
            AssetDataPath = assetData.ResourcePath;
            if (assetData.OriginalCanNotRemovedItem != null) {
                OriginalCanNotRemovedItem = assetData.OriginalCanNotRemovedItem.GetSaveData();
            }
        }

        public bool CanEquipItem(SaveData_Item saveDataItem) {
            if (AssetData.AllAllowedItemLabels.All(data=>saveDataItem.AssetData.AllLabels.Contains(data) == false)) {
                return false;
            }

            return true;
        }
    }
}