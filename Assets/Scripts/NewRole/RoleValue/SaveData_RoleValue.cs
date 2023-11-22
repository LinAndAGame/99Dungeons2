using System;
using UnityEngine;
using Utility;

namespace NewRole {
    [Serializable]
    public class SaveData_RoleValue {
        public RoleValueTypeEnum RoleValueType => AssetData.RoleValueTypeEnum;
        public int               Value;

        [SerializeField]
        private string AssetDataPath;
        public AssetData_RoleValue AssetData => Resources.Load<AssetData_RoleValue>(AssetDataPath);
        
        public SaveData_RoleValue() { }
        
        public SaveData_RoleValue(RoleValueTypeEnum roleValueType, int value) {
            Value         = value;

            AssetDataPath = GameCommonAsset.I.AllAssetDataRoleValues.Find(data => data.RoleValueTypeEnum == roleValueType).ResourcePath;
        }
    }
}