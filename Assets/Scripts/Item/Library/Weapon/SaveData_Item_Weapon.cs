using Role;
using Utility;

namespace Item {
    public class SaveData_Item_Weapon : SaveData_ItemWithAssetData<AssetData_Item_Weapon> {
        public SaveData_Item_Weapon(AssetData_Item_Weapon assetData) : base(assetData) { }
        
        public override SystemData_Item GetSystemData(RoleCtrl roleCtrl) {
            return new SystemData_Item_Weapon(roleCtrl, this);
        }
    }
}