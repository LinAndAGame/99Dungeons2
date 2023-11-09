using System;
using MyGameUtility;
using UnityEngine;

namespace Role.UnlockAction {
    [Serializable]
    public abstract class SaveData_RoleUnlock {
        public Guid UniqueId;
        [SerializeField]
        protected string FixedDataName;
        protected CacheCollection CC = new CacheCollection();

        public SaveData_RoleUnlock() { }

        public SaveData_RoleUnlock(BaseRoleUnlockFixedData roleUnlockFixedData) {
            FixedDataName = roleUnlockFixedData.name;
            UniqueId      = System.Guid.NewGuid();
        }

        public abstract void Init(SaveData_Role saveDataRole);

        public abstract BaseRoleUnlockActionBattle GetRoleUnlockActionBattle();
    }
}