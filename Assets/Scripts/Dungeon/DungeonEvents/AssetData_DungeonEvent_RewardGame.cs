using BattleScene;
using Dungeon.SystemData;
using UnityEngine;

namespace Dungeon {
    [CreateAssetMenu(fileName = "DungeonEvent_奖励游戏", menuName = "纯数据资源/Dungeon/Event/奖励游戏", order = 0)]
    public class AssetData_DungeonEvent_RewardGame : AssetData_BaseDungeonEvent {
        public string GameSucceedContent;
        public string GameFailureContent;

        public override ISystemData_DungeonEvent_CallBacks GetCallBacks() {
            return new SystemData_DungeonEvent_RewardGame(this);
        }
    }
}