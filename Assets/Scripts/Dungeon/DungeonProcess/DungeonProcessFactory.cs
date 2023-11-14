namespace Dungeon {
    public static class DungeonProcessFactory {
        public static SaveData_DungeonProcess CreateSaveData(AssetData_DungeonProcess assetData) {
            return new SaveData_DungeonProcess(assetData);
        }

        public static SystemData_DungeonProcess CreateSystemData(SaveData_DungeonProcess saveData) {
            return new SystemData_DungeonProcess(saveData);
        }
    }
}