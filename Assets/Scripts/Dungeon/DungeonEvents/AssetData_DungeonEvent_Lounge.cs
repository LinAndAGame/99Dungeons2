/*
 * 休息事件，使一个角色恢复满血或全队角色恢复20%血量
 */

using BattleScene;
using Dungeon.SystemData;
using UnityEngine;

namespace Dungeon {
    [CreateAssetMenu(fileName = "DungeonEvent_休息区域", menuName = "纯数据资源/Dungeon/Event/休息区域", order = 0)]
    public class AssetData_DungeonEvent_Lounge : AssetData_BaseDungeonEvent {
        public override ISystemData_DungeonEvent_CallBacks GetCallBacks() {
            return new SystemData_DungeonEvent_Lounge(this);
        }
    }
}