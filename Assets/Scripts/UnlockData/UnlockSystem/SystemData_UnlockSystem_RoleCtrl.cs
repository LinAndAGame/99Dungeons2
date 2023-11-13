using System;
using Role;
using UnlockData.UnlockProcess;

namespace UnlockData.UnlockSystem {
    public class SystemData_UnlockSystem_RoleCtrl : SystemData_UnlockSystem<RoleCtrl> {
        public SystemData_UnlockSystem_RoleCtrl(RoleCtrl dataOwner, SaveData_UnlockSystem saveData) : base(dataOwner, saveData) { }

        protected override SystemData_BaseUnlockProcess<RoleCtrl> GetUnlockProcess(SaveData_UnlockProcess saveDataUnlockProcess) {
            switch (saveDataUnlockProcess.AssetData.UnlockProcessType) {
                case UnlockProcessTypeEnum.RoleOnlyUseShieldWin:
                    return new SystemData_UnlockProcess_RoleOnlyUseShieldWin(DataOwner, this, saveDataUnlockProcess);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}