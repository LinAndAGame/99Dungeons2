using UnityEngine;

namespace Dungeon.SystemData {
    public abstract class SystemData_BaseDungeonEvent<T> : ISystemData_DungeonEvent_CallBacks where T : AssetData_BaseDungeonEvent {
        private   string AssetDataPath;
        protected T      AssetData => Resources.Load<T>(AssetDataPath);

        protected SystemData_BaseDungeonEvent(T assetData) {
            AssetDataPath = assetData.ResourcePath;
        }

        public virtual void Init() { }
        public virtual void ClearData (){ }
    }
}