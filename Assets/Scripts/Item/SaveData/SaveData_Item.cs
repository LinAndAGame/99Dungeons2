using System;
using System.Collections.Generic;
using Role;
using UnityEngine;

namespace Item {
    [Serializable]
    public abstract class SaveData_Item {
        public int Count;

        [SerializeField]
        private string AssetDataPath;

        public AssetData_Item AssetData => Resources.Load<AssetData_Item>(AssetDataPath);

        public SaveData_Item() { }

        public SaveData_Item(AssetData_Item assetDataItem) {
            AssetDataPath = assetDataItem.ResourcePath;
            Count         = 1;
        }

        public abstract SystemData_Item GetSystemData(RoleCtrl roleCtrl);
    }
}