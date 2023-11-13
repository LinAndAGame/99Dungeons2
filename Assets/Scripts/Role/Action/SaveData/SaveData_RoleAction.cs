using System;
using UnityEngine;

namespace Role.Action {
    [Serializable]
    public abstract class SaveData_RoleAction {
        [SerializeField]
        private string AssetDataPath;
        public AssetData_RoleAction AssetData => Resources.Load<AssetData_RoleAction>(AssetDataPath);
        
        public SaveData_RoleAction() { }

        public SaveData_RoleAction(AssetData_RoleAction roleAction) {
            AssetDataPath = roleAction.ResourcePath;
        }

        public abstract SystemData_BaseRoleAction GetSystemDataRoleAction(RoleCtrl roleCtrl);
    }
}