using Role;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Role {
    public static class RoleCreator {
        public static RoleCtrl CreateRole(SaveData_Role saveDataRole) {
            var rolePrefabObj = Addressables.LoadAssetAsync<GameObject>("Assets/Prefab/Role/Role.prefab");
            rolePrefabObj.WaitForCompletion();
            var roleCtrl = UnityEngine.Object.Instantiate(rolePrefabObj.Result).GetComponent<RoleCtrl>();
            roleCtrl.Init(saveDataRole);
            return roleCtrl;
        }
    }
}