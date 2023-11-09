﻿namespace Item {
    public class SaveData_Item_Armor : SaveData_ItemWithAssetData<AssetData_Item_Armor> {
        public SaveData_Item_Armor(AssetData_Item_Armor assetData) : base(assetData) { }
        public override SystemData_Item GetSystemData() {
            return new SystemData_Item_Armor(this);
        }
    }
}