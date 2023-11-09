using System.Collections.Generic;
using Role.Action;
using UnityEngine;

namespace Role.UnlockAction {
    public abstract class BaseRoleUnlockFixedData : ScriptableObject {
        public List<AssetData_RoleAction> AllUnlockedRoleActionDatas;

        public List<SaveData_RoleAction> GetAllSaveDataRoleActions {
            get {
                List<SaveData_RoleAction> result = new List<SaveData_RoleAction>();
                foreach (AssetData_RoleAction unlockedRoleActionData in AllUnlockedRoleActionDatas) {
                    result.Add(unlockedRoleActionData.GetSaveData());
                }

                return result;
            }
        }

        public abstract SaveData_RoleUnlock GetRoleUnlockData();
    }
}