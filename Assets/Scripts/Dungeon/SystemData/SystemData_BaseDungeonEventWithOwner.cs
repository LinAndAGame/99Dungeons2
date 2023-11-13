namespace Dungeon.SystemData {
    public class SystemData_BaseDungeonEventWithOwner<T> : SystemData_BaseDungeonEvent where T : AssetData_BaseDungeonEvent {
        public T AssetDataT => AssetData as T;
        public SystemData_BaseDungeonEventWithOwner(AssetData_BaseDungeonEvent assetData) : base(assetData) { }
    }
}