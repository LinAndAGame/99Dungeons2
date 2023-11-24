using System;
using System.Collections.Generic;
using NewRole;
using UnityEngine;

namespace Card {
    [Serializable]
    public class SaveData_Card {
        public BaseSaveData_CardEffect       MainCardEffect;
        public List<BaseSaveData_CardEffect> AllAdditionalCardEffects = new List<BaseSaveData_CardEffect>();
        public List<SaveData_RoleValue>      AllRoleValues = new List<SaveData_RoleValue>();

        [SerializeField]
        private string              AssetDataPath;
        public  AssetData_Card AssetData => Resources.Load<AssetData_Card>(AssetDataPath);

        public SaveData_Card() { }

        public SaveData_Card(AssetData_Card assetData) {
            AssetDataPath  = assetData.ResourcePath;
            MainCardEffect = CardEffectFactory.GetSaveData(assetData.MainCardEffect);
            foreach (var saveDataAllAdditionalCardEffect in assetData.AllAdditionalCardEffects) {
                AllAdditionalCardEffects.Add(CardEffectFactory.GetSaveData(saveDataAllAdditionalCardEffect));
            }
            
            foreach (ClassData_RoleValue classDataRoleValue in assetData.AllRoleValues) {
                AllRoleValues.Add(new SaveData_RoleValue(classDataRoleValue));
            }
        }
    }
}