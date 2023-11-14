using System;
using UnityEngine;

namespace Role.Brand {
    [Serializable]
    public class SaveData_Brand {
        public  SaveData_Weakness SaveDataWeakness;
        
        [SerializeField]
        private string AssetDataPath;
        public AssetData_Brand AssetData => Resources.Load<AssetData_Brand>(AssetDataPath);

        public SaveData_Brand() { }

        public SaveData_Brand(AssetData_Brand assetDataBrand) {
            SaveDataWeakness = new SaveData_Weakness(assetDataBrand.AssetDataWeakness);
        }
    }
}