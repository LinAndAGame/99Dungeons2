using Utility;

namespace NewRole {
    public static class RoleFactory {
        public static RoleCtrl CreateRoleCtrl(RuntimeData_Role runtimeDataRole, bool isPlayer) {
            RoleCtrl prefab = null;
            if (isPlayer) {
                prefab = GameCommonAsset.I.RolePlayerPrefab;
            }
            else {
                prefab = GameCommonAsset.I.RoleEnemyPrefab;
            }
            var ins = UnityEngine.Object.Instantiate(prefab);
            ins.Init(runtimeDataRole);
            return ins;
        }

        public static RoleCtrl CreateRoleCtrl(AssetData_Role assetDataRole, bool isPlayer) {
            return CreateRoleCtrl(CreateSaveData(assetDataRole), isPlayer);
        }

        public static RoleCtrl CreateRoleCtrl(SaveData_Role saveDataRole, bool isPlayer) {
            return CreateRoleCtrl(CreateRuntimeData(saveDataRole), isPlayer);
        }

        public static SaveData_Role CreateSaveData(AssetData_Role assetDataRole) {
            return new SaveData_Role(assetDataRole);
        }

        public static RuntimeData_Role CreateRuntimeData(SaveData_Role saveDataRole) {
            return new RuntimeData_Role(saveDataRole);
        }
    }
}