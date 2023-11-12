using System.Collections.Generic;
using BattleScene;
using Dungeon;
using Dungeon.EncounterEnemy;
using UnityEngine;

namespace UnlockData.UnlockElement {
    [CreateAssetMenu(fileName = "UnlockElement_DungeonEvent", menuName = "纯数据资源/Unlock/UnlockElement_DungeonEvent")]
    public class AssetData_UnlockElement_DungeonEvent : AssetData_BaseUnlockElement {
        public List<AssetData_BaseDungeonEvent> AllDungeonEvents;

        public override List<string> GetUnlockNames() {
            List<string> result = new List<string>();
            foreach (AssetData_BaseDungeonEvent assetDataBaseDungeonEvent in AllDungeonEvents) {
                result.Add(assetDataBaseDungeonEvent.EventName);
            }

            return result;
        }
    }
}