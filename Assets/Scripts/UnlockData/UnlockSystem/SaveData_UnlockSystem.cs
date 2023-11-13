using System;
using System.Collections.Generic;
using UnlockData.UnlockProcess;

namespace UnlockData.UnlockSystem {
    [Serializable]
    public class SaveData_UnlockSystem {
        public List<SaveData_UnlockProcess> AllUnlockProcesses = new List<SaveData_UnlockProcess>();

        public SaveData_UnlockSystem() { }

        public SaveData_UnlockSystem(List<AssetData_UnlockProcess> assetDataUnlockProcesses) {
            foreach (var assetDataUnlockProcess in assetDataUnlockProcesses) {
                AllUnlockProcesses.Add(new SaveData_UnlockProcess(assetDataUnlockProcess));
            }
        }
    }
}