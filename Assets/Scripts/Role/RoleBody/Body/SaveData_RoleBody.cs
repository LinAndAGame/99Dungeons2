using System;
using System.Collections.Generic;

namespace Role.RoleBody {
    [Serializable]
    public class SaveData_RoleBody {
        public List<SaveData_RoleBodySlot> AllBodySlots = new List<SaveData_RoleBodySlot>();

        public SaveData_RoleBody() {
            
        }

        public SaveData_RoleBody(AssetData_RoleBody assetDataRoleBody) {
            foreach (AssetData_RoleBodySlot assetDataRoleBodySlot in assetDataRoleBody.AllRoleBodySlots) {
                AllBodySlots.Add(new SaveData_RoleBodySlot(assetDataRoleBodySlot));
            }
        }
    }
}