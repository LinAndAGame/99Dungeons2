using System.Collections.Generic;
using Item;
using Role;

namespace Dungeon.EncounterEnemy {
    public class EncounterEnemySettlement {
        public List<SaveData_Role>                       AllBeKilledEnemies  = new List<SaveData_Role>();
        public List<SaveData_Item>                       AllEncounterRewards = new List<SaveData_Item>();
        public List<EncounterEnemySettlement_UnlockInfo> AllUnlockInfos      = new List<EncounterEnemySettlement_UnlockInfo>();
    }
}