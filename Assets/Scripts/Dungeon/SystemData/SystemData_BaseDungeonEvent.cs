using UnityEngine;

namespace Dungeon.SystemData {
    public abstract class SystemData_BaseDungeonEvent {
        private   string AssetDataPath;
        protected AssetData_BaseDungeonEvent      AssetData => Resources.Load<AssetData_BaseDungeonEvent>(AssetDataPath);

        protected SystemData_BaseDungeonEvent(AssetData_BaseDungeonEvent assetData) {
            AssetDataPath = assetData.ResourcePath;
        }

        public virtual void Init() { }
        public virtual void ClearData (){ }
    }
}