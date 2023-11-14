using Dungeon.EncounterEnemy;
using Dungeon.SystemData;

namespace Dungeon {
    public static class DungeonEventFactory {
        public static SaveData_BaseDungeonEvent CreateSaveData<T>(T assetData) where T : AssetData_BaseDungeonEvent {
            if (assetData is AssetData_DungeonEvent_EncounterEnemy encounterEnemy) {
                return new SaveData_DungeonEvent_EncounterEnemy(encounterEnemy);
            }
            else if (assetData is AssetData_DungeonEvent_Lounge lounge) {
                return new SaveData_DungeonEvent_Lounge(lounge);
            }
            else if (assetData is AssetData_DungeonEvent_RewardGame rewardGame) {
                return new SaveData_DungeonEvent_RewardGame(rewardGame);
            }
            else if (assetData is AssetData_DungeonEvent_ReturnTown returnTown) {
                return new SaveData_DungeonEvent_ReturnTown(returnTown);
            }

            return null;
        }

        public static SystemData_BaseDungeonEvent CreateSystemData<T>(T saveData) where T : SaveData_BaseDungeonEvent {
            if (saveData is SaveData_DungeonEvent_EncounterEnemy encounterEnemy) {
                return new SystemData_DungeonEvent_EncounterEnemy(encounterEnemy);
            }
            else if (saveData is SaveData_DungeonEvent_Lounge lounge) {
                return new SystemData_DungeonEvent_Lounge(lounge);
            }
            else if (saveData is SaveData_DungeonEvent_RewardGame rewardGame) {
                return new SystemData_DungeonEvent_RewardGame(rewardGame);
            }
            else if (saveData is SaveData_DungeonEvent_ReturnTown returnTown) {
                return new SystemData_DungeonEvent_ReturnTown(returnTown);
            }

            return null;
        }
    }
}