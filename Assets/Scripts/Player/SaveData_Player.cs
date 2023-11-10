using System;
using System.Collections.Generic;
using Item;
using MyGameUtility;
using MyGameUtility.SaveLoad;
using Role;
using Unity.VisualScripting;
using UnlockData;
using Utility;

namespace Player {
    [Serializable]
    public class SaveData_Player {
        private const string SaveDataPlayerKey = "SaveDataPlayer";

        private static SaveData_Player _I;

        public static SaveData_Player I {
            get {
                if (_I == null) {
                    if (ES3.KeyExists(SaveDataPlayerKey) == false) {
                        _I = new SaveData_Player();
                        foreach (var assetDataRole in GameCommonAsset.I.DefaultPlayerData.AllTeamRoles) {
                            _I.AllUsedTeamRoles.Add(new SaveData_Role(assetDataRole, true));
                        }

                        ES3.Save(SaveDataPlayerKey, _I);
                    }
                    else {
                        _I = ES3.Load<SaveData_Player>(SaveDataPlayerKey);
                    }
                }

                return _I;
            }
        }

        public List<SaveData_Role> AllUsedTeamRoles  = new List<SaveData_Role>();
        public List<SaveData_Item> AllInventoryItems = new List<SaveData_Item>();
        public List<SaveData_Unlock> 

        public SaveData_Player() { }

        public void SaveAsync() {
            SaveLoadUtility.AsyncSaveByEs3(SaveDataPlayerKey, this, ES3Settings.defaultSettings);
        }
    }
}