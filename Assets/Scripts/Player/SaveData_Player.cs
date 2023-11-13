using System;
using System.Collections.Generic;
using System.Linq;
using Item;
using MyGameUtility;
using MyGameUtility.SaveLoad;
using Role;
using Role.RoleBody;
using Unity.VisualScripting;
using UnlockData;
using UnlockData.UnlockProcess;
using UnlockData.UnlockSystem;
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
                            _I.AllUsedTeamRoles.Add(new SaveData_Role(assetDataRole, true));
                        }
                        foreach (AssetData_Item assetDataItem in GameCommonAsset.I.DefaultPlayerData.AllInventoryItems) {
                            _I.AllInventoryItems.Add(assetDataItem.GetSaveData());
                        }

                        _I.UnlockSystem = new SaveData_UnlockSystem(GameCommonAsset.I.DefaultPlayerData.AllUnlockProcesses);

                        ES3.Save(SaveDataPlayerKey, _I);
                    }
                    else {
                        _I = ES3.Load<SaveData_Player>(SaveDataPlayerKey);
                    }
                }

                return _I;
            }
        }

        public List<SaveData_Role>           AllUsedTeamRoles  = new List<SaveData_Role>();
        public List<SaveData_Item>           AllInventoryItems = new List<SaveData_Item>();
        public SaveData_UnlockSystem         UnlockSystem;
        public SaveData_UnlockDataCollection SaveDataUnlockDataCollection = new SaveData_UnlockDataCollection();
        public bool                          PlayerConfirmStartGameItem;

        public SaveData_Player() { }

        public void SwitchItem(SaveData_RoleItemSlot roleItemSlot, SaveData_Item saveDataItem) {
            var itemIndex = AllInventoryItems.IndexOf(saveDataItem);
            if (roleItemSlot.OverrideItem != null) {
                AllInventoryItems[itemIndex] = roleItemSlot.OverrideItem;
            }
            else {
                AllInventoryItems.RemoveAt(itemIndex);
            }

            roleItemSlot.OverrideItem = saveDataItem;
            SaveAsync();
        }

        public void SaveSync() {
            ES3.Save(SaveDataPlayerKey, _I);
        }

        public void SaveAsync() {
            SaveLoadUtility.AsyncSaveByEs3(SaveDataPlayerKey, this, ES3Settings.defaultSettings);
        }
    }
}