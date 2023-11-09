using System.Collections.Generic;

namespace Dungeon {
    public class DungeonProcess {
        public readonly AssetData_DungeonLevel DungeonLevel;
        
        public AssetData_BaseDungeonEvent CurDungeonEvent { get; set; }
        
        public DungeonProcess(AssetData_DungeonLevel dungeonLevel) {
            DungeonLevel = dungeonLevel;
        }

        public void RunFirstDungeonEvent() {
            RunDungeonEvent(DungeonLevel.AllDungeonEvents[0]);
        }

        public List<AssetData_BaseDungeonEvent> GetAllNextPossibleDungeonEvents() {
            List<AssetData_BaseDungeonEvent> result = new List<AssetData_BaseDungeonEvent>();
            result.AddRange(DungeonLevel.AllDungeonEvents);
            return result;
        }

        public void RunDungeonEvent(AssetData_BaseDungeonEvent dungeonEvent) {
            CurDungeonEvent = dungeonEvent;
            CurDungeonEvent.Init();
        }
    }
}