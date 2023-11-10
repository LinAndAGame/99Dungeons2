using UnityEngine;

namespace UnlockData {
    public abstract class SaveData_UnlockT<T> : SaveData_Unlock where T : AssetData_Unlock {
        public T AssetData => Resources.Load<T>(AssetDataPath);

        public SaveData_UnlockT(T assetData) : base(assetData) { }
    }
}