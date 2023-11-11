using System;
using System.Linq;
using Item;
using UnityEngine;
using Utility;

namespace Role.RoleBody {
    [Serializable]
    public class SaveData_RoleItemSlot {
        [SerializeField]
        private string AssetDataName;
        public SaveData_Item EquippedItem;
        
        public AssetData_RoleItemSlot AssetData => Resources.Load<AssetData_RoleItemSlot>($"{GameCommonAsset.I.AssetFolderInfo_RoleEquipmentSlot}{AssetDataName}");

        public SaveData_RoleItemSlot() { }
        
        public SaveData_RoleItemSlot(AssetData_RoleItemSlot assetData) {
            AssetDataName = assetData.name;
            if (assetData.DefaultEquippedItem != null) {
                EquippedItem = assetData.DefaultEquippedItem.GetSaveData();
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