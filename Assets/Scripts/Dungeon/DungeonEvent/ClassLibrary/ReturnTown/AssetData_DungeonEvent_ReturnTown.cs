using Dungeon.SystemData;
using UnityEngine;

namespace Dungeon {
    [CreateAssetMenu(fileName = "DungeonEvent_返回城镇", menuName = "纯数据资源/Dungeon/Event/返回城镇", order = 0)]
    public class AssetData_DungeonEvent_ReturnTown : AssetData_BaseDungeonEvent {
        public string ReturnTownContent;
    }
}