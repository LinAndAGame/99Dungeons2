namespace Item {
    public class SaveData_Item_Shield : SaveData_ItemWithAssetData<AssetData_Item_Shield> {
        public SaveData_Item_Shield(AssetData_Item_Shield assetData) : base(assetData) { }
        
        public override SystemData_Item GetSystemData() {
            return new SystemData_Item_Shield(this);
        }
    }
}