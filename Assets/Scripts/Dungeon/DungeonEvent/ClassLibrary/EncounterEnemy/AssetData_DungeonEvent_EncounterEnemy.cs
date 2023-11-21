using System;
using System.Collections.Generic;
using Dungeon.SystemData;
using MyGameUtility;
using NewRole;
using Role;
using UnityEngine;

namespace Dungeon.EncounterEnemy {
    [CreateAssetMenu(fileName = "DungeonEvent_遭遇敌人", menuName = "纯数据资源/Dungeon/Event/遭遇敌人", order = 0)]
    public class AssetData_DungeonEvent_EncounterEnemy : AssetData_BaseDungeonEvent {
        public int                  EnemyLevel;
        public List<AssetData_Role> Enemies;
    }
}