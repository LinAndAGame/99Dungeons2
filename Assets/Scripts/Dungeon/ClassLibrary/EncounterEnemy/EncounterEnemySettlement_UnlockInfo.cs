using Role;

namespace Dungeon.EncounterEnemy {
    public class EncounterEnemySettlement_UnlockInfo {
        public SaveData_Role SaveDataRole;
        public string        UnlockName;

        public EncounterEnemySettlement_UnlockInfo(SaveData_Role saveDataRole, string unlockName) {
            SaveDataRole = saveDataRole;
            UnlockName   = unlockName;
        }
    }
}