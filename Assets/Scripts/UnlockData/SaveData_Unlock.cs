using System;
using UnityEngine;

namespace UnlockData {
    [Serializable]
    public abstract class SaveData_Unlock {
        public bool   IsUnlocked;
        
        [SerializeField]
        protected string AssetDataPath;
        public AssetData_Unlock BaseAssetData => Resources.Load<AssetData_Unlock>(AssetDataPath);

        public SaveData_Unlock() { }

        public SaveData_Unlock(AssetData_Unlock assetData) {
            AssetDataPath = assetData.ResourcePath;
        }

        public abstract SystemData_Unlock GetSystemData();
    }
}