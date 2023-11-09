using System;
using System.Collections.Generic;
using System.Linq;
using Role.UnlockAction;
using UnityEngine;
using Utility;

namespace Role {
    public class SaveData_RoleIdentity {
        public string     IdentityName;
        public Guid       UniqueId;
        public List<Guid> AllUnlockDataGuids = new List<Guid>();

        public BaseRoleIdentity AssetData => Resources.Load<BaseRoleIdentity>($"{GameCommonAsset.I.AssetFolderInfo_RoleIdentity}{IdentityName}");

        public SaveData_RoleIdentity() { }
        
        public SaveData_RoleIdentity(string identityName) {
            IdentityName = identityName;
            UniqueId = System.Guid.NewGuid();
        }

        public List<SaveData_RoleUnlock> GetInitUnlockDatas() {
            List<SaveData_RoleUnlock> result = AssetData.AllPossibleUnlockFixedDatas.Select(data=>data.GetRoleUnlockData()).ToList();
            foreach (SaveData_RoleUnlock saveDataRoleUnlock in result) {
                AllUnlockDataGuids.Add(saveDataRoleUnlock.UniqueId);
            }

            return result;
        }
    }
}