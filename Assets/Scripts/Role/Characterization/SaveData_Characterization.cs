using UnityEngine;

namespace Role.Characterization {
    public class SaveData_Characterization {
        public string ResourcePath;

        public AssetData_Characterization AssetData => Resources.Load<AssetData_Characterization>(ResourcePath);

        public SaveData_Characterization() { }

        public SaveData_Characterization(AssetData_Characterization assetData) {
            ResourcePath = assetData.ResourcePath;
        }
    }
}