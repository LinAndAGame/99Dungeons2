using System.Collections.Generic;
using Item;
using Role;

namespace Dungeon.EncounterEnemy {
    public class EncounterEnemySettlement {
        public List<SaveData_Role>                       AllBeKilledEnemies;
        public List<SaveData_Item>                       AllEncounterRewards;
        public List<EncounterEnemySettlement_UnlockInfo> AllUnlockInfos;
    }
}