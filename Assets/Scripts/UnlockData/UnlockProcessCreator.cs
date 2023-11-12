using System;
using Role;
using UnlockData.UnlockProcess;

namespace UnlockData {
    public static class UnlockProcessCreator {
        public static SystemData_BaseUnlockProcess GetUnlockProcess(SaveData_UnlockProcess saveDataUnlockProcess) {
            switch (saveDataUnlockProcess.AssetData.UnlockProcessType) {
                case UnlockProcessTypeEnum.PlayerCreateOctopusMan:
                    return new SystemData_UnlockProcess_PlayerCreateOctopusMan(saveDataUnlockProcess);
                case UnlockProcessTypeEnum.RoleOnlyUseShieldWin:
                    return new SystemData_UnlockProcess_RoleOnlyUseShieldWin(roleCtrl, saveDataUnlockProcess);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}