using System;
using UnityEngine;

namespace RandomValue.RandomEffect {
    [Serializable]
    public abstract class SaveData_BaseRandomValueEffect {
        [SerializeField]
        private string AssetDataPath;

        public AssetData_BaseRandomValueEffect AssetData => Resources.Load<AssetData_BaseRandomValueEffect>(AssetDataPath);

        public SaveData_BaseRandomValueEffect() { }

        public SaveData_BaseRandomValueEffect(AssetData_BaseRandomValueEffect assetData) {
            AssetDataPath = assetData.ResourcePath;
        }
    }
}