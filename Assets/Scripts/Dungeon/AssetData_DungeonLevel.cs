using System.Collections.Generic;
using MyGameExpand;
using UnityEngine;

namespace Dungeon {
    [CreateAssetMenu(fileName = "DungeonLevel", menuName = "纯数据资源/Dungeon/Level", order = 0)]
    public class AssetData_DungeonLevel : ScriptableObject {
        public List<AssetData_BaseDungeonEvent> AllDungeonEvents;
        public List<AssetData_BaseDungeonEvent> AllHiddenDungeonEvents;

        public AssetData_BaseDungeonEvent GetDungeonEvent() {
            return AllDungeonEvents.GetRandomElement();
        }
    }
}