using UnityEngine;
using Utility;

namespace Role.Action {
    public abstract class SaveData_RoleActionWithAssetData<T> : SaveData_RoleAction where T : AssetData_RoleAction {
        public T AssetDataT => AssetData as T;
        protected SaveData_RoleActionWithAssetData(AssetData_RoleAction roleAction) : base(roleAction) { }
    }
}