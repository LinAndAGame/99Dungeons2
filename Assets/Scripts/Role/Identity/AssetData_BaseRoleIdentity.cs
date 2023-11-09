using System.Collections.Generic;
using Role.UnlockAction;
using UnityEngine;

namespace Role {
    public abstract class AssetData_BaseRoleIdentity : ScriptableObject {
        public string                        IdentityName;
        public List<BaseRoleUnlockFixedData> AllPossibleUnlockFixedDatas;

        public abstract bool IsMeetIdentityRequirement(SaveData_Role saveDataRole);

        public SaveData_RoleIdentity GetSaveDataRoleIdentity() {
            return new SaveData_RoleIdentity(this.name);
        }
    }
}