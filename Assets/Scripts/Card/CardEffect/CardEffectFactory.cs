namespace Card {
    public static class CardEffectFactory {
        public static BaseSaveData_CardEffect GetSaveData(BaseAssetData_CardEffect assetData) {
            if (assetData is AssetData_CardEffect_AttackByValueType attackByValueType) {
                return new SaveData_CardEffect_AttackByValueType(attackByValueType);
            }
            else if (assetData is AssetData_CardEffect_Heal heal) {
                return new SaveData_CardEffect_Heal(heal);
            }

            return null;
        }

        public static BaseRuntimeData_CardEffect GetRuntimeData(BaseSaveData_CardEffect saveData) {
            if (saveData is SaveData_CardEffect_AttackByValueType attackByValueType) {
                return new RuntimeData_CardEffect_AttackByValueType(attackByValueType);
            }
            else if (saveData is SaveData_CardEffect_Heal heal) {
                return new RuntimeData_CardEffect_Heal(heal);
            }

            return null;
        }
    }
}