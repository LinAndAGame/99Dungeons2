using Utility;

namespace NewRole {
    public static class RoleFactory {
        public static RoleCtrl CreateRoleCtrl(RuntimeData_Role runtimeDataRole) {
            var ins = UnityEngine.Object.Instantiate(GameCommonAsset.I.RoleCtrlPrefab);
            ins.Init(runtimeDataRole);
            return ins;
        }
    }
}