using System;
using Player;
using UnlockData.UnlockProcess;

namespace UnlockData.UnlockSystem {
    public class SystemData_UnlockSystem_Player : SystemData_UnlockSystem<SystemData_Player> {
        public SystemData_UnlockSystem_Player(SystemData_Player                                                    dataOwner, SaveData_UnlockSystem saveData) : base(dataOwner, saveData) { }
        protected override SystemData_BaseUnlockProcess<SystemData_Player> GetUnlockProcess(SaveData_UnlockProcess saveDataUnlockProcess) {
            
            switch (saveDataUnlockProcess.AssetData.UnlockProcessType) {
                case UnlockProcessTypeEnum.PlayerCreateOctopusMan:
                    return new SystemData_UnlockProcess_PlayerCreateOctopusMan(DataOwner, this, saveDataUnlockProcess);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}