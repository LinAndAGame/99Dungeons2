using System;
using UnityEngine;

namespace NewSkillCard {
    [Serializable]
    public class SaveData_Card {
        private string              AssetDataPath;
        public  AssetData_Card AssetData => Resources.Load<AssetData_Card>(AssetDataPath);

        public SaveData_Card() { }

        public SaveData_Card(AssetData_Card assetData) {
            AssetDataPath = assetData.ResourcePath;
        }
    }
}