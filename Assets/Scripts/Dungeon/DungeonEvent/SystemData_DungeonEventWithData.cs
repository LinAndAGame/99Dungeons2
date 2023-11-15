using Dungeon.SystemData;
using MyGameUtility;

namespace Dungeon {
    public class SystemData_DungeonEventWithData<T> : SystemData_BaseDungeonEvent where T : SaveData_BaseDungeonEvent {
        public T SaveDataT => SaveData as T;
        public SystemData_DungeonEventWithData(SaveData_BaseDungeonEvent saveData) : base(saveData) { }
    }
}