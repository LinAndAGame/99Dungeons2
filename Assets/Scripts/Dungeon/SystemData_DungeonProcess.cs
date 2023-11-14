using System.Collections.Generic;

namespace Dungeon {
    public class SystemData_DungeonProcess {
        public readonly AssetData_DungeonProcess CurDungeonProcess;
        
        public AssetData_BaseDungeonEvent CurDungeonEvent { get; set; }
        
        public SystemData_DungeonProcess(AssetData_DungeonProcess curDungeonProcess) {
            CurDungeonProcess = curDungeonProcess;
        }

        public void RunFirstDungeonEvent() {
            RunDungeonEvent(CurDungeonProcess.AllDungeonEvents[0]);
        }

        public List<AssetData_BaseDungeonEvent> GetAllNextPossibleDungeonEvents() {
            List<AssetData_BaseDungeonEvent> result = new List<AssetData_BaseDungeonEvent>();
            result.AddRange(CurDungeonProcess.AllDungeonEvents);
            return result;
        }

        public void RunDungeonEvent(AssetData_BaseDungeonEvent dungeonEvent) {
            CurDungeonEvent = dungeonEvent;
            CurDungeonEvent.RunThisDungeonEvent();
        }
    }
}