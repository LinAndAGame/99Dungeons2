using System.Collections.Generic;
using Dungeon.SystemData;
using MyGameExpand;
using MyGameUtility;

namespace Dungeon {
    public class SystemData_DungeonProcess : BaseSystemData<SaveData_DungeonProcess, AssetData_DungeonProcess> {
        private DungeonProcessStateEnum           _DungeonProcessState;
        private SystemData_BaseDungeonEvent       _CurRunningDungeonEvent;
        
        private List<SystemData_BaseDungeonEvent> _AllPossibleChosenDungeonEvents = new List<SystemData_BaseDungeonEvent>();
        private List<SystemData_BaseDungeonEvent> _AllDungeonEvents               = new List<SystemData_BaseDungeonEvent>();

        public SystemData_DungeonProcess(SaveData_DungeonProcess saveData) : base(saveData) { }
        
        public T GetDungeonEventCallBack<T>() where T : SystemData_BaseDungeonEvent {
            return _CurRunningDungeonEvent as T;
        }

        public void GetAllPossibleDungeonEvent() {
            // 获取所有可能的5个地牢事件
            _AllPossibleChosenDungeonEvents.Clear();
            foreach (var dungeonEvent in _AllDungeonEvents) {
                if (dungeonEvent.CanUseThisDungeonEvent() == false) {
                    continue;
                }

                _AllPossibleChosenDungeonEvents.Add(dungeonEvent);
            }

            _AllPossibleChosenDungeonEvents = _AllPossibleChosenDungeonEvents.GetRandomList(SaveData.AssetData.MaxDungeonEvent);
            
            // 运行所有地牢事件的DisplayHandle，因为有的地牢事件可能会对其他地牢事件产生影响
            foreach (var dungeonEvent in _AllPossibleChosenDungeonEvents) {
                dungeonEvent.DisplayHandle();
            }
        }

        public void ChooseDungeonEvent(SystemData_BaseDungeonEvent dungeonEvent) {
            _CurRunningDungeonEvent = dungeonEvent;
            _CurRunningDungeonEvent.ChooseHandle();
            foreach (var possibleChosenDungeonEvent in _AllPossibleChosenDungeonEvents) {
                if (possibleChosenDungeonEvent == dungeonEvent) {
                    continue;
                }
                
                possibleChosenDungeonEvent.NotChooseHandle();
            }
        }

        public void CancelDungeonEvent(SystemData_BaseDungeonEvent dungeonEvent) {
            
        }
    }
}