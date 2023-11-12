using UnityEngine;

namespace Item {
    public abstract class SaveData_ItemWithAssetData<T> : SaveData_Item where T : AssetData_Item {
        public T AssetDataT => AssetData as T;

        protected SaveData_ItemWithAssetData(AssetData_Item assetDataItem) : base(assetDataItem) { }
    }
}