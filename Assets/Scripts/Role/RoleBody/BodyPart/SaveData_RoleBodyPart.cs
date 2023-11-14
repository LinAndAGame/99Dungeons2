using System;
using System.Collections.Generic;
using UnityEngine;

namespace Role.RoleBody {
    [Serializable]
    public class SaveData_RoleBodyPart {
        [SerializeField]
        private string AssetDataPath;
        public List<SaveData_RoleItemSlot> AllRoleItemSlots = new List<SaveData_RoleItemSlot>();
        public List<SaveData_Weakness>     AllWeaknesses    = new List<SaveData_Weakness>();

        public AssetData_RoleBodyPart AssetData => Resources.Load<AssetData_RoleBodyPart>(AssetDataPath);
        
        public SaveData_RoleBodyPart() { }

        public SaveData_RoleBodyPart(AssetData_RoleBodyPart assetDataRoleBodyPart) {
            AssetDataPath = assetDataRoleBodyPart.ResourcePath;
            foreach (var assetDataRoleEquipmentSlot in AssetData.AllRoleItemSlots) {
                AllRoleItemSlots.Add(assetDataRoleEquipmentSlot.GetSaveData());
            }
            foreach (AssetData_Weakness assetDataAllWeakness in AssetData.AllWeaknesses) {
                AllWeaknesses.Add(new SaveData_Weakness(assetDataAllWeakness));
            }
        }
    }
}