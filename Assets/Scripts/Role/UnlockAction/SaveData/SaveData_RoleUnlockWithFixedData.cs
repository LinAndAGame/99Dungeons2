using UnityEngine;
using Utility;

namespace Role.UnlockAction {
    public abstract class BaseRoleUnlockWithFixedData<T> : SaveData_RoleUnlock where T : BaseRoleUnlockFixedData {
        public T FixedData => Resources.Load<T>($"{GameCommonAsset.I.AssetFolderInfo_RoleUnlockAction}{FixedDataName}");

        protected BaseRoleUnlockWithFixedData(BaseRoleUnlockFixedData roleUnlockFixedData) : base(roleUnlockFixedData) { }
    }
}