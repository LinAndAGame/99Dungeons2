using Utility;

namespace Item {
    public class SaveData_Item_Weapon : SaveData_ItemWithAssetData<AssetData_Item_Weapon> {
        public SaveData_Item_Weapon(AssetData_Item_Weapon assetData) : base(assetData) { }
        
        public override SystemData_Item GetSystemData() {
            return new SystemData_Item_Weapon(this);
        }
    }
}