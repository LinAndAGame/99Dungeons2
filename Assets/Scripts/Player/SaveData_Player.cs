using System;
using System.Collections.Generic;
using Dungeon;
using MyGameUtility.SaveLoad;
using NewRole;
using Utility;

namespace Player {
    [Serializable]
    public class SaveData_Player {
        public const string SaveDataPlayerKey = "SaveDataPlayer";

        private static SaveData_Player _I;

        public static SaveData_Player I {
            get {
                if (_I == null) {
                    if (ES3.KeyExists(SaveDataPlayerKey) == false) {
                        _I = new SaveData_Player();
                        foreach (var assetDataRole in GameCommonAsset.I.DefaultPlayerData.AllTeamRoles) {
                            _I.AllUsedTeamRoles.Add(RoleFactory.CreateSaveData(assetDataRole));
                        }

                        _I.DungeonProcess = DungeonProcessFactory.CreateSaveData(GameCommonAsset.I.DungeonProcess);

                        ES3.Save(SaveDataPlayerKey, _I);
                    }
                    else {
                        _I = ES3.Load<SaveData_Player>(SaveDataPlayerKey);
                    }
                }

                return _I;
            }
        }

        public List<SaveData_Role>   AllUsedTeamRoles  = new List<SaveData_Role>();
        public SaveData_DungeonProcess       DungeonProcess;

        public SaveData_Player() { }

        public void SaveSync() {
            ES3.Save(SaveDataPlayerKey, _I);
        }

        public void SaveAsync() {
            SaveLoadUtility.AsyncSaveByEs3(SaveDataPlayerKey, this, ES3Settings.defaultSettings);
        }
    }
}