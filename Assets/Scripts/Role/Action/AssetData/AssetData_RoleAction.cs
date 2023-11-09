using UnityEngine;

namespace Role.Action {
    public abstract class AssetData_RoleAction : ScriptableObject {
        public string              RoleActionName => this.name;

        public abstract SaveData_RoleAction GetSaveData();
    }
}