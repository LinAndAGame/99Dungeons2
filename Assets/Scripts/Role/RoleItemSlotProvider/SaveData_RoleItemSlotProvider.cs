using System;
using System.Collections.Generic;
using Role.RoleItemSlot;
using UnityEngine;
using Utility;

namespace Role.RoleItemSlotProvider {
    [Serializable]
    public class SaveData_RoleItemSlotProvider {
        [SerializeField]
        private string AssetDataName;
        public bool                             IsActive;
        public List<SaveData_RoleItemSlot> AllRoleItemSlots = new List<SaveData_RoleItemSlot>();

        public AssetData_RoleItemSlotProvider AssetData => Resources.Load<AssetData_RoleItemSlotProvider>($"{GameCommonAsset.I.AssetFolderInfo_RoleItemSlotProvider}{AssetDataName}");
        
        public SaveData_RoleItemSlotProvider() { }

        public SaveData_RoleItemSlotProvider(AssetData_RoleItemSlotProvider assetDataRoleItemSlotProvider) {
            AssetDataName = assetDataRoleItemSlotProvider.name;
            foreach (var assetDataRoleEquipmentSlot in AssetData.AllRoleEquipmentSlots) {
                AllRoleItemSlots.Add(assetDataRoleEquipmentSlot.GetSaveData());
            }
        }
    }
}