using System.Collections.Generic;
using UnlockData.UnlockProcess;

namespace UnlockData.UnlockSystem {
    public abstract class SystemData_UnlockSystem<T> {
        private SaveData_UnlockSystem SaveData;

        protected T DataOwner;

        public SystemData_UnlockSystem(T dataOwner,  SaveData_UnlockSystem saveData) {
            DataOwner = dataOwner;
            SaveData  = saveData;
            
            foreach (var saveDataUnlockProcess in SaveData.AllUnlockProcesses) {
                RunUnlockProcess(saveDataUnlockProcess);
            }
        }

        public List<SystemData_BaseUnlockProcess<T>> AllUnlockProcess = new List<SystemData_BaseUnlockProcess<T>>();
        
        public void RemoveAndRuneNextUnlockProcess(SystemData_BaseUnlockProcess<T> unlockProcess) {
            AllUnlockProcess.Remove(unlockProcess);
            SaveData.AllUnlockProcesses.Remove(unlockProcess.SaveData);
            
            foreach (AssetData_UnlockProcess assetDataUnlockProcess in unlockProcess.SaveData.AssetData.NextUnlockProcess) {
                SaveData_UnlockProcess saveDataUnlockProcess = new SaveData_UnlockProcess(assetDataUnlockProcess);
                SaveData.AllUnlockProcesses.Add(saveDataUnlockProcess);
                RunUnlockProcess(saveDataUnlockProcess);
            }
        }

        private void RunUnlockProcess(SaveData_UnlockProcess saveDataUnlockProcess) {
            AllUnlockProcess.Add(GetUnlockProcess(saveDataUnlockProcess));
        }

        protected abstract SystemData_BaseUnlockProcess<T> GetUnlockProcess(SaveData_UnlockProcess saveDataUnlockProcess);
    }
}