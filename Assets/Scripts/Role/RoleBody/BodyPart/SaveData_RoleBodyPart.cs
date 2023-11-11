using System;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Role.RoleBody {
    [Serializable]
    public class SaveData_RoleBodyPart {
        [SerializeField]
        private string AssetDataName;
        public bool                             IsActive;
        public List<SaveData_RoleItemSlot> AllRoleItemSlots = new List<SaveData_RoleItemSlot>();

        public AssetData_RoleBodyPart AssetData => Resources.Load<AssetData_RoleBodyPart>($"{GameCommonAsset.I.AssetFolderInfo_RoleItemSlotProvider}{AssetDataName}");
        
        public SaveData_RoleBodyPart() { }

        public SaveData_RoleBodyPart(AssetData_RoleBodyPart assetDataRoleBodyPart) {
            AssetDataName = assetDataRoleBodyPart.name;
            foreach (var assetDataRoleEquipmentSlot in AssetData.AllRoleEquipmentSlots) {
                AllRoleItemSlots.Add(assetDataRoleEquipmentSlot.GetSaveData());
            }
        }
    }
}