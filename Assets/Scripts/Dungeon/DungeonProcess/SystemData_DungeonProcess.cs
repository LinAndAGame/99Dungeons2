using System.Collections.Generic;
using Dungeon.SystemData;
using MyGameExpand;
using MyGameUtility;

namespace Dungeon {
    public class SystemData_DungeonProcess : BaseSystemData<SaveData_DungeonProcess, AssetData_DungeonProcess> {
        public CustomAction OnDisplayHandleFinished = new CustomAction();
        
        private DungeonProcessStateEnum           _DungeonProcessState;
        private SystemData_BaseDungeonEvent       _CurRunningDungeonEvent;
        
        public List<SystemData_BaseDungeonEvent> AllPossibleChosenDungeonEvents = new List<SystemData_BaseDungeonEvent>();
        public List<SystemData_BaseDungeonEvent> AllDungeonEvents               = new List<SystemData_BaseDungeonEvent>();

        public Queue<DungeonEventHandleGroup>     DisplayHandleQueue = new Queue<DungeonEventHandleGroup>();
        public Queue<SystemData_BaseDungeonEvent> DisplayEventQueue  = new Queue<SystemData_BaseDungeonEvent>();

        public SystemData_DungeonProcess(SaveData_DungeonProcess saveData) : base(saveData) {
            foreach (SaveData_BaseDungeonEvent saveDataBaseDungeonEvent in saveData._AllDungeonEvents) {
                AllDungeonEvents.Add(DungeonEventFactory.CreateSystemData(saveDataBaseDungeonEvent));
            }
        }
        
        public T GetDungeonEventCallBack<T>() where T : SystemData_BaseDungeonEvent {
            return _CurRunningDungeonEvent as T;
        }

        public void TryRunDisplayHandle() {
            if (DisplayHandleQueue.Count > 0) {
                var displayHandle = DisplayHandleQueue.Dequeue();
                displayHandle.Seq.onComplete += TryRunDisplayHandle;
                displayHandle.Handle();
            }
            else {
                if (DisplayEventQueue.Count > 0) {
                    var displayEvent = DisplayEventQueue.Dequeue();   
                    displayEvent.DisplayHandle();
                }
                else {
                    OnDisplayHandleFinished.Invoke();
                }
            }
        }

        public void RunDisplayHandle() {
            foreach (SystemData_BaseDungeonEvent systemDataBaseDungeonEvent in AllPossibleChosenDungeonEvents) {
                DisplayEventQueue.Enqueue(systemDataBaseDungeonEvent);
            }
        }

        public List<SystemData_BaseDungeonEvent> GetAllPossibleDungeonEvent() {
            // 获取所有可能的5个地牢事件
            AllPossibleChosenDungeonEvents.Clear();
            foreach (var dungeonEvent in AllDungeonEvents) {
                if (dungeonEvent.CanUseThisDungeonEvent() == false) {
                    continue;
                }

                AllPossibleChosenDungeonEvents.Add(dungeonEvent);
            }

            AllPossibleChosenDungeonEvents = AllPossibleChosenDungeonEvents.GetRandomList(SaveData.AssetData.MaxDungeonEvent);

            return AllPossibleChosenDungeonEvents;
        }

        public void ChooseDungeonEvent(SystemData_BaseDungeonEvent dungeonEvent) {
            _CurRunningDungeonEvent = dungeonEvent;
            _CurRunningDungeonEvent.ChooseHandle();
            foreach (var possibleChosenDungeonEvent in AllPossibleChosenDungeonEvents) {
                if (possibleChosenDungeonEvent == dungeonEvent) {
                    continue;
                }
                
                possibleChosenDungeonEvent.NotChooseHandle();
            }
        }
    }
}