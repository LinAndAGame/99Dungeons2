using System.Collections.Generic;
using System.Linq;
using Player;
using Role;
using Role.Action;
using UnityEngine;

namespace UnlockData.UnlockElement {
    [CreateAssetMenu(fileName = "UnlockElement_RoleAction", menuName = "纯数据资源/Unlock/UnlockElement_RoleAction")]
    public class AssetData_UnlockElement_RoleAction : AssetData_BaseUnlockElement {
        public List<AssetData_RoleAction> AllUnlockRoleActions;

        public override List<string> GetUnlockNames() => AllUnlockRoleActions.Select(data => data.RoleActionName).ToList();

        public override void AddToRole(SaveData_Role saveDataRole) {
            base.AddToRole(saveDataRole);
            foreach (var assetDataRoleAction in AllUnlockRoleActions) {
                saveDataRole.AllLearnedRoleActions.Add(assetDataRoleAction.GetSaveData());
            }
            SaveData_Player.I.SaveSync();
        }
    }
}