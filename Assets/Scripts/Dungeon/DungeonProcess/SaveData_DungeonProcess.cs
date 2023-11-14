using System.Collections.Generic;
using Dungeon.SystemData;
using MyGameUtility;

namespace Dungeon {
    public class SaveData_DungeonProcess : BaseSaveData<AssetData_DungeonProcess> {
        private DungeonProcessStateEnum         _DungeonProcessState;
        private SaveData_BaseDungeonEvent       _CurRunningDungeonEvent;
        public  List<SaveData_BaseDungeonEvent> _AllPossibleChosenDungeonEvents = new List<SaveData_BaseDungeonEvent>();
        public  List<SaveData_BaseDungeonEvent> _AllDungeonEvents               = new List<SaveData_BaseDungeonEvent>();

        public SaveData_DungeonProcess(AssetData_DungeonProcess assetData) : base(assetData) { }
    }
}