using RandomValue.RandomEffect;

namespace RandomValue {
    public static class RandomValueFactory {
        public static SaveData_BaseRandomValueEffect GetSaveData(AssetData_BaseRandomValueEffect assetData) {
            if (assetData is AssetData_RandomValueEffect_BuffGiver buffGiver) {
                return new SaveData_RandomValueEffect_BuffGiver(buffGiver);
            }

            return null;
        }

        public static RuntimeData_BaseRandomValueEffect GetRuntimeData(SaveData_BaseRandomValueEffect saveData) {
            if (saveData is SaveData_RandomValueEffect_BuffGiver buffGiver) {
                return new RuntimeData_RandomValueEffect_BuffGiver(buffGiver);
            }

            return null;
        }
    }
}