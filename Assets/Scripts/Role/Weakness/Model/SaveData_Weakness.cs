using System;
using MyGameUtility;
using UnityEngine;

namespace Role {
    [Serializable]
    public class SaveData_Weakness {
        public MinMaxValueFloat WeaknessValue;

        public WeaknessTypeEnum WeaknessType => AssetData.WeaknessType;
        
        [SerializeField]
        private string ResourcePath;
        public AssetData_Weakness AssetData => Resources.Load<AssetData_Weakness>(ResourcePath);

        public SaveData_Weakness() { }

        public SaveData_Weakness(AssetData_Weakness assetData) {
            ResourcePath  = assetData.ResourcePath;
            WeaknessValue = new MinMaxValueFloat(0, assetData.DefaultMaxValue, 0);
        }
    }
}