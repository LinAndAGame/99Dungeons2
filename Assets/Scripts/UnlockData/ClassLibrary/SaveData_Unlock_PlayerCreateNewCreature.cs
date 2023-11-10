namespace UnlockData {
    public class SaveData_Unlock_PlayerCreateNewCreature : SaveData_UnlockT<AssetData_Unlock_PlayerCreateNewCreature> {
        public SaveData_Unlock_PlayerCreateNewCreature(AssetData_Unlock_PlayerCreateNewCreature assetData) : base(assetData) { }
        
        public override SystemData_Unlock GetSystemData() {
            return new SystemData_Unlock_PlayerCreateNewCreature(this);
        }
    }
}