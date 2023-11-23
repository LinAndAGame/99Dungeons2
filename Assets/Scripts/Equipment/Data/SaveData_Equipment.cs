using System;
using System.Collections.Generic;
using Card;
using NewRole;
using UnityEngine;

namespace Equipment {
    [Serializable]
    public class SaveData_Equipment {
        public List<SaveData_RoleValueChanger> AllRoleValueChangers = new List<SaveData_RoleValueChanger>();
        public SaveData_Card                   SaveDataCard;

        [SerializeField]
        private string AssetDataPath;
        public AssetData_Equipment AssetData => Resources.Load<AssetData_Equipment>(AssetDataPath);

        public SaveData_Equipment() {
            
        }

        public SaveData_Equipment(AssetData_Equipment assetData) {
            AssetDataPath = assetData.ResourcePath;

            foreach (var roleValueChanger in assetData.AllRoleValueChangers) {
                AllRoleValueChangers.Add(new SaveData_RoleValueChanger(roleValueChanger));
            }

            SaveDataCard = new SaveData_Card(assetData.Card);
        }
    }
}