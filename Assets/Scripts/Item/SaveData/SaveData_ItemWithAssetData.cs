using UnityEngine;

namespace Item {
    public abstract class SaveData_ItemWithAssetData<T> : SaveData_Item where T : AssetData_Item {
        public T AssetData => Resources.Load<T>($"{PathPrefix()}{AssetDataName}"); 

        protected SaveData_ItemWithAssetData(T assetData) {
            AssetDataName = assetData.name;
        }
    }
}