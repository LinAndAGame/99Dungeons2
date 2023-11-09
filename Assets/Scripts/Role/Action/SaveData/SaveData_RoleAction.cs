using System;

namespace Role.Action {
    [Serializable]
    public abstract class SaveData_RoleAction {
        public string ActionName;
        
        public SaveData_RoleAction() { }

        public SaveData_RoleAction(AssetData_RoleAction roleAction) {
            ActionName = roleAction.RoleActionName;
        }

        public abstract SystemData_BaseRoleAction GetSystemDataRoleAction(RoleCtrl roleCtrl);
    }
}