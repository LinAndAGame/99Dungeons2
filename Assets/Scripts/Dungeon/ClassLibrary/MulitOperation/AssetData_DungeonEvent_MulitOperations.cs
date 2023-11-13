using System.Collections.Generic;
using Dungeon.SystemData;
using UnityEngine;

namespace Dungeon {
    [CreateAssetMenu(fileName = "DungeonEvent_多选题", menuName = "纯数据资源/Dungeon/Event/多选题", order = 0)]
    public class AssetData_DungeonEvent_MulitOperations : AssetData_BaseDungeonEvent {
        public override SystemData_BaseDungeonEvent GetCallBacks() {
            return new SystemData_DungeonEvent_MulitOperations(this);
        }
    }
}