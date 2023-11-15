using MyGameUtility;

namespace Dungeon.EncounterEnemy {
    public class SaveData_DungeonEvent_EncounterEnemy : SaveData_BaseDungeonEventWithData<AssetData_DungeonEvent_EncounterEnemy> {
        public int EnemyLv;
        public int NotChosenTimes;
        
        public SaveData_DungeonEvent_EncounterEnemy(AssetData_DungeonEvent_EncounterEnemy assetData) : base(assetData) { }
    }
}