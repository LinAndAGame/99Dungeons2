using System;
using UnityEngine;

namespace Role.RoleBody {
    [Serializable]
    public class SaveData_RoleBodySlot {
        public bool                  IsActive = true;
        public SaveData_RoleBodyPart SaveDataRoleBodyPart;
        
        [SerializeField]
        private string ResourcePath;
        public AssetData_RoleBodySlot AssetData => Resources.Load<AssetData_RoleBodySlot>(ResourcePath);

        public SaveData_RoleBodySlot() { }

        public SaveData_RoleBodySlot(AssetData_RoleBodySlot assetDataRoleBodySlot) {
            ResourcePath         = assetDataRoleBodySlot.ResourcePath;
            if (assetDataRoleBodySlot.DefaultRoleBodyPart != null) {
                SaveDataRoleBodyPart = new SaveData_RoleBodyPart(assetDataRoleBodySlot.DefaultRoleBodyPart);
            }
        }
    }
}