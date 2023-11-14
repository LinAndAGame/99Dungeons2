using MyGameUtility;

namespace Dungeon {
    public abstract class AssetData_BaseDungeonEvent : BaseAssetData {
        public DungeonEventTypeEnum DungeonEventType;
        public string               EventName;
        public string               StartEventContent;
    }
}