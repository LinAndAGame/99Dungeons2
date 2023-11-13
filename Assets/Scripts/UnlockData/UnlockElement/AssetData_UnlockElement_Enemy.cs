using System.Collections.Generic;
using System.Linq;
using BattleScene;
using Dungeon;
using Dungeon.EncounterEnemy;
using Player;
using Role;
using UnityEngine;

namespace UnlockData.UnlockElement {
    [CreateAssetMenu(fileName = "UnlockElement_Enemy", menuName = "纯数据资源/Unlock/UnlockElement_Enemy")]
    public class AssetData_UnlockElement_Enemy : AssetData_BaseUnlockElement {
        public List<AssetData_RoleEnemy> AllUnlockEnemies;
        public override List<string> GetUnlockNames() => AllUnlockEnemies.Select(data => data.RoleName).ToList();
    }
}