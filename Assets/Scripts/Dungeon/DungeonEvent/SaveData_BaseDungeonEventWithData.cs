using MyGameUtility;
using UnityEngine;

namespace Dungeon {
    public class SaveData_BaseDungeonEventWithData<T> : SaveData_BaseDungeonEvent where T : AssetData_BaseDungeonEvent {
        public T AssetDataT => AssetData as T;
        public SaveData_BaseDungeonEventWithData(T assetData) : base(assetData) { }
    }
}