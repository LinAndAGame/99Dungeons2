using System.Collections.Generic;
using MyGameUtility;
using UnityEngine;

namespace Dungeon {
    [CreateAssetMenu(fileName = "DungeonProcess", menuName = "纯数据资源/Dungeon/DungeonProcess")]
    public class AssetData_DungeonProcess : BaseAssetData {
        public int                              MaxDungeonEvent = 5;
        public List<AssetData_BaseDungeonEvent> AllDefaultOpenedDungeonEvents;
    }
}