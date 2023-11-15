using MyGameUtility;

namespace Dungeon {
    public abstract class AssetData_BaseDungeonEvent : BaseAssetData {
        public float                OriginalRandomValue;
        public DungeonEventTypeEnum DungeonEventType;
        public string               EventName;
        public string               StartEventContent;
    }
}