using System.Collections.Generic;
using Item;
using Role;
using Role.Action;
using Role.RoleBody;
using UnlockData;
using UnlockData.UnlockProcess;
using Utility;

namespace Player {
    public class SystemData_Player {
        private static SystemData_Player _I;
        public static SystemData_Player I {
            get {
                if (_I == null) {
                    _I = new SystemData_Player();
                    foreach (SaveData_UnlockProcess saveDataUnlockProcess in SaveData_Player.I.AllUnlockProcess) {
                        I.AllUnlockProcess.Add(UnlockProcessCreator.GetUnlockProcess(saveDataUnlockProcess));
                    }
                }

                return _I;
            }
        }

        public CustomAction OnRoleBodyChanged = new CustomAction();

        public List<SystemData_BaseUnlockProcess> AllUnlockProcess = new List<SystemData_BaseUnlockProcess>();
        
        public SaveData_Player SaveData => SaveData_Player.I;

        public void RemoveAndRuneNextUnlockProcess(SystemData_BaseUnlockProcess unlockProcess) {
            AllUnlockProcess.Remove(unlockProcess);
            SaveData.AllUnlockProcess.Remove(unlockProcess.SaveData);
            
            foreach (AssetData_UnlockProcess assetDataUnlockProcess in unlockProcess.SaveData.AssetData.NextUnlockProcess) {
                SaveData_UnlockProcess saveDataUnlockProcess = new SaveData_UnlockProcess(assetDataUnlockProcess);
                SaveData.AllUnlockProcess.Add(saveDataUnlockProcess);
                AllUnlockProcess.Add(UnlockProcessCreator.GetUnlockProcess(saveDataUnlockProcess));
            }
        }
    }
}