using System;
using System.Collections.Generic;
using UnityEngine;

namespace NewSkillCard {
    [Serializable]
    public class SaveData_Card {
        public BaseSaveData_CardEffect       MainCardEffect;
        public List<BaseSaveData_CardEffect> AllAdditionalCardEffects = new List<BaseSaveData_CardEffect>();
        
        private string              AssetDataPath;
        public  AssetData_Card AssetData => Resources.Load<AssetData_Card>(AssetDataPath);

        public SaveData_Card() { }

        public SaveData_Card(AssetData_Card assetData) {
            AssetDataPath  = assetData.ResourcePath;
            MainCardEffect = CardEffectFactory.GetSaveData(assetData.MainCardEffect);
            foreach (var saveDataAllAdditionalCardEffect in assetData.AllAdditionalCardEffects) {
                AllAdditionalCardEffects.Add(CardEffectFactory.GetSaveData(saveDataAllAdditionalCardEffect));
            }
        }
    }
}