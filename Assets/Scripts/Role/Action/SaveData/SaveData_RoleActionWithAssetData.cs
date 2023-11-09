using UnityEngine;
using Utility;

namespace Role.Action {
    public abstract class SaveData_RoleActionWithAssetData<T> : SaveData_RoleAction where T : AssetData_RoleAction {
        public T AssetData => Resources.Load<T>($"{GameCommonAsset.I.AssetFolderInfo_RoleAction}{ActionName}");
        protected SaveData_RoleActionWithAssetData(AssetData_RoleAction roleAction) : base(roleAction) { }
    }
}